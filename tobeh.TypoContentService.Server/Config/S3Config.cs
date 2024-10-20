namespace tobeh.TypoContentService.Server.Config;

public class S3Config{
    public required string AccessKey { get; init; }
    public required string SecretKey { get; init; }
    public required string CloudBucket { get; init; }
    public required string ServiceUrl { get; init; }
};