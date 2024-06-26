using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using ImageMagick;
using Microsoft.Extensions.Options;
using tobeh.TypoContentService.Server.Config;
using tobeh.Valmar;
using tobeh.Valmar.Client.Util;

namespace tobeh.TypoContentService.Server.Service;

public class ComboImageGenerator(
    ILogger<ComboImageGenerator> logger, 
    Sprites.SpritesClient spritesClient, 
    CachedFileProvider cachedFileProvider, 
    IOptions<ImageGeneratorConfig> options
)
{
    public async Task<List<FileChunkMessage>> GenerateComboFromSprites(GenerateComboMessage request)
    {
        logger.LogTrace("GenerateComboFromUrls(request={request})", request);

        var spriteIds = request.SpriteIds.Where(id => id > 0).ToList();
        if (spriteIds.Count == 0)
        {
            return
            [
                new FileChunkMessage { ChunkIndex = 0, Chunk = ByteString.Empty, FileType = "png", Name = "empty.png" }
            ];
        }
        
        var resultFileName = $"url-combo-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

        var allSprites = await spritesClient.GetAllSprites(new Empty()).ToDictionaryAsync(sprite => sprite.Id);
        var combo = spriteIds.Select(id => allSprites[id]).ToList();
        var colorMap = request.ColorMaps.ToDictionary(map => map.SpriteId, map => map.HueShift);
        
        var bytesTasks = combo.Select(async sprite => new {Bytes = await cachedFileProvider.GetBytesFromUrl(sprite.Url), Sprite = sprite});
        var bytes = await Task.WhenAll(bytesTasks);
     
        var comboImage = new MagickImage(MagickColors.Transparent, 80, 80);
        foreach (var imageBytes in bytes)
        {
            using var collection = new MagickImageCollection(imageBytes.Bytes);
            var modulated = collection[0].Clone();
            
            if(colorMap.TryGetValue(imageBytes.Sprite.Id, out var hueShift))
            {
                modulated.Modulate(new Percentage(100), new Percentage(100), new Percentage(hueShift));
            }
            
            comboImage.Composite(modulated, CompositeOperator.Over);
        }

        if (comboImage is null) throw new Exception("No frames added");
        comboImage.Format = MagickFormat.Png;
     
        var resultBytes = comboImage.ToByteArray();
        var byteChunks = resultBytes.Chunk(options.Value.ByteChunkKByte * 1024);
     
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