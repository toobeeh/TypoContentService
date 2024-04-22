using Google.Protobuf;
using ImageMagick;
using Microsoft.Extensions.Options;
using TypoImageGen.Config;
using TypoImageGenerator;

namespace TypoImageGen.Service;

public class ComboImageGenerator(ILogger<ComboImageGenerator> logger, CachedFileProvider cachedFileProvider, IOptions<ImageGeneratorConfig> _options)
{
    public async Task<List<GeneratedImageMessage>> GenerateComboFromUrls(GenerateComboFromUrlsMessage request)
    {
        logger.LogTrace("GenerateComboFromUrls(request={request})", request);
        
        var resultFileName = $"url-combo-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
     
        var bytesTasks = request.SourceUrls.Select(url => cachedFileProvider.GetBytesFromUrl(url));
        var bytes = await Task.WhenAll(bytesTasks);
     
        IMagickImage? comboImage = null;
        foreach (var imageBytes in bytes)
        {
            using var collection = new MagickImageCollection(imageBytes);
            if (comboImage is not null)
            {
                comboImage.Composite(collection[0], CompositeOperator.Over);
            }
            else
            {
                comboImage = collection[0].Clone();
            }
        }

        if (comboImage is null) throw new Exception("No frames added");
        comboImage.Format = MagickFormat.Png;
     
        var resultBytes = comboImage.ToByteArray();
        var byteChunks = resultBytes.Chunk(_options.Value.ByteChunkKByte * 1024);
     
        var messages = byteChunks.Select((chunk, index) => new GeneratedImageMessage
        {
            ChunkIndex = index,
            Chunk = ByteString.CopyFrom(chunk),
            Name = resultFileName,
            FileType = "png"
        }).ToList();

        return messages;
    }
}