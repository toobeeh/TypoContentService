namespace tobeh.TypoContentService.Server.Config;

public class ImageGeneratorConfig{
    public required string CachePath { get; init; }
    public required int ByteChunkKByte { get; init; }
};