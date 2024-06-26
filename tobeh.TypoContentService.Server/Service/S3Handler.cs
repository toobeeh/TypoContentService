using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using tobeh.TypoContentService.Server.Config;

namespace tobeh.TypoContentService.Server.Service;

public class S3Handler(IOptions<S3Config> config)
{
    private readonly BasicAWSCredentials _credentials = new BasicAWSCredentials(config.Value.AccessKey, config.Value.SecretKey);

    private readonly AmazonS3Config _config = new ()
    {
        ServiceURL = "https://eu2.contabostorage.com/",
        ForcePathStyle = true,
    };

    public async Task<string> UploadPng(string path, string name)
    {
        name += ".png";
        var client = new AmazonS3Client(_credentials, _config);
        var putRequest = new PutObjectRequest
        {
            BucketName = "palantir",
            Key = name,
            FilePath = path,
            ContentType = "image/png",
            CannedACL = S3CannedACL.PublicRead
        };

        var response = await client.PutObjectAsync(putRequest);
        return "https://eu2.contabostorage.com/45a0651c8baa459daefd432c0307bb5b:palantir/" + name;
    }
}