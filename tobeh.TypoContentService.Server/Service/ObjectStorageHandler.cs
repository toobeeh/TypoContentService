using System.Net.Mime;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using MimeTypes;
using tobeh.TypoContentService.Server.Config;

namespace tobeh.TypoContentService.Server.Service;

public class ObjectStorageHandler(IOptions<S3Config> config, ILogger<ObjectStorageHandler> logger)
{
    private readonly AmazonS3Client _client = new (
        new BasicAWSCredentials(config.Value.AccessKey, config.Value.SecretKey),  
        new AmazonS3Config
        {
            ServiceURL = config.Value.ServiceUrl,
            ForcePathStyle = true
        });

    public async Task<string> UploadFileToBucket(string bucket, string name, string fileExtension, byte[] content)
    {
        logger.LogTrace("UploadFileToBucket({bucket}, {name}, {fileExtension}, {content})", bucket, name, fileExtension, content);

        // compute mime type
        string contentType;
        try
        {
            contentType = MimeTypeMap.GetMimeType(fileExtension);
        }
        catch (Exception)
        {
            contentType = MediaTypeNames.Application.Octet;
        }

        var key = $"{name}.{fileExtension}";
        
        // fill request details
        var putRequest = new PutObjectRequest
        {
            BucketName = bucket,
            Key = key,
            ContentType = contentType,
            CannedACL = S3CannedACL.PublicRead
        };
        
        // write content to request and upload
        putRequest.InputStream = new MemoryStream(content);
        await _client.PutObjectAsync(putRequest);

        return key;
    }
    
    public async Task DeleteFileFromBucket(string bucket, string name)
    {
        logger.LogTrace("DeleteFileFromBucket({bucket}, {name})", bucket, name);
        
        var deleteRequest = new DeleteObjectRequest
        {
            BucketName = bucket,
            Key = name
        };
        
        await _client.DeleteObjectAsync(deleteRequest);
    }
}