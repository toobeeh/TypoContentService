using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using ImageMagick;
using Microsoft.Extensions.Options;
using tobeh.TypoImageGen;
using tobeh.TypoImageGen.Server.Config;
using tobeh.Valmar;
using tobeh.Valmar.Client.Util;

namespace tobeh.TypoImageGen.Server.Service;

public class ComboImageGenerator(
    ILogger<ComboImageGenerator> logger, 
    Sprites.SpritesClient spritesClient, 
    CachedFileProvider cachedFileProvider, 
    IOptions<ImageGeneratorConfig> _options
)
{
    public async Task<List<FileChunkMessage>> GenerateComboFromUrls(GenerateComboMessage request)
    {
        logger.LogTrace("GenerateComboFromUrls(request={request})", request);
        
        var resultFileName = $"url-combo-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

        var allSprites = await spritesClient.GetAllSprites(new Empty()).ToDictionaryAsync(sprite => sprite.Id);
        var combo = request.SpriteIds.Select(id => allSprites[id]).ToList();
        
        var bytesTasks = combo.Select(sprite => cachedFileProvider.GetBytesFromUrl(sprite.Url));
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
     
        var messages = byteChunks.Select((chunk, index) => new FileChunkMessage
        {
            ChunkIndex = index,
            Chunk = ByteString.CopyFrom(chunk),
            Name = resultFileName,
            FileType = "png"
        }).ToList();

        return messages;
    }
}