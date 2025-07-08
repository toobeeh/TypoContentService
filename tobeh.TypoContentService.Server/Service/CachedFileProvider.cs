using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using tobeh.TypoContentService.Server.Config;

namespace tobeh.TypoContentService.Server.Service;

public class CachedFileProvider
{
    private readonly ImageGeneratorConfig _config;
    private readonly HttpClient _httpClient;
    private readonly ILogger<CachedFileProvider> _logger;
    
    private const string ProxyApiKey = "6d207e02198a847aa98d0a2a901485a5";
    private const string ProxyUploadUrl = "https://freeimage.host/api/1/upload";
    
    private string GetCachePath(string base64Path) => Path.Combine(_config.CachePath, base64Path);
    
    public CachedFileProvider(IOptions<ImageGeneratorConfig> config, IHttpClientFactory httpClientFactory, ILogger<CachedFileProvider> logger)
    {
        _config = config.Value;
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient();
        Directory.CreateDirectory(_config.CachePath);
    }
    
    public async Task<byte[]> GetBytesFromUrl(string url)
    {
        _logger.LogTrace("GetBytesFromUrl(url={url})", url);
        
        var base64Url = Convert.ToBase64String(Encoding.UTF8.GetBytes(url)).Replace("/", "_");
        
        var cachePath = GetCachePath(base64Url);
        if (File.Exists(cachePath))
        {
            _logger.LogDebug("Loading file {cachePath} for url {url} from cache", cachePath, url);
            return await File.ReadAllBytesAsync(cachePath);
        }

        _logger.LogDebug("Fetching and caching file from url {url} from cache", url);
        
        // workaround for hetzner server, where imgur blocks requests
        // if not cached locally: upload to freeimghost via provided imgur url, and then download from freeimghost (de facto proxy)

        var bytes = await ProxyDownloadViaFreeImageHost(url);
        
        await File.WriteAllBytesAsync(cachePath, bytes);
        return bytes;
    }

    private async Task<byte[]> ProxyDownloadViaFreeImageHost(string imgurUrl)
    {
        _logger.LogTrace("ProxyDownloadViaFreeImageHost(imgurUrl={imgurUrl})", imgurUrl);
        
        var form = new MultipartFormDataContent();
        form.Add(new StringContent(ProxyApiKey), "key");
        form.Add(new StringContent(imgurUrl), "source");
        form.Add(new StringContent("json"), "format");
        form.Add(new StringContent("upload"), "action");
        
        var response = await _httpClient.PostAsync(ProxyUploadUrl, form);
        var json = await response.Content.ReadAsStringAsync();
        _logger.LogDebug("Received response from freeimage.host: {json}", json);
        
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        var imageUrl = root
            .GetProperty("image")
            .GetProperty("url")
            .GetString();
        
        byte[] imageBytes = await _httpClient.GetByteArrayAsync(imageUrl);
        return imageBytes;
    }
}