using System.Text;
using Microsoft.Extensions.Options;
using TypoImageGen.Config;

namespace TypoImageGen.Service;

public class CachedFileProvider
{
    private readonly ImageGeneratorConfig _config;
    private readonly HttpClient _httpClient;
    private readonly ILogger<CachedFileProvider> _logger;
    
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
        
        var base64Url = Convert.ToBase64String(Encoding.UTF8.GetBytes(url));
        
        var cachePath = GetCachePath(base64Url);
        if (File.Exists(cachePath))
        {
            _logger.LogDebug("Loading file {cachePath} for url {url} from cache", cachePath, url);
            return await File.ReadAllBytesAsync(cachePath);
        }

        _logger.LogDebug("Fetching and caching file from url {url} from cache", url);
        var bytes = await _httpClient.GetByteArrayAsync(url);
        
        await File.WriteAllBytesAsync(cachePath, bytes);
        return bytes;
    }
}