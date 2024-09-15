using Microsoft.Extensions.Options;
using tobeh.TypoContentService.Server.Config;

namespace tobeh.TypoContentService.Server.Service;

public class CloudService(IOptions<S3Config> config, ILogger<CloudService> logger, ObjectStorageHandler objectStorageHandler)
{
    private readonly string _bucketName = config.Value.CloudBucket;
    
    public async Task UploadImageToCloud(byte[] imageBytes, byte[] commandBytes, byte[] metaBytes, string userFolder,
        long imageId)
    {
        logger.LogTrace("UploadImageToCloud({userFolder}, {imageId})", userFolder, imageId);

        string? imagePath = null, commandsPath = null, metaPath = null;
        try
        {
            // Upload the image
            imagePath = await objectStorageHandler.UploadFileToBucket(_bucketName, $"{userFolder}/{imageId}/image", "png", imageBytes);

            // Upload the commands
            commandsPath = await objectStorageHandler.UploadFileToBucket(_bucketName, $"{userFolder}/{imageId}/commands", "json", commandBytes);

            // Upload the meta
            metaPath = await objectStorageHandler.UploadFileToBucket(_bucketName, $"{userFolder}/{imageId}/meta", "json", metaBytes);
        }
        catch (Exception e)
        {
            logger.LogError("Failed to upload image to cloud: {e}", e);

            if (imagePath != null)
            {
                try
                {
                    await objectStorageHandler.DeleteFilesFromBucket(_bucketName, [imagePath]);
                }
                catch (Exception deleteException)
                {
                    logger.LogError("Failed to clean up image upload after failure: {deleteException}", deleteException);
                }
            }
            if (commandsPath != null)
            {
                try
                {
                    await objectStorageHandler.DeleteFilesFromBucket(_bucketName, [commandsPath]);
                }
                catch (Exception deleteException)
                {
                    logger.LogError("Failed to clean up commands upload after failure: {deleteException}", deleteException);
                }
            }
            if (metaPath != null)
            {
                try
                {
                    await objectStorageHandler.DeleteFilesFromBucket(_bucketName, [metaPath]);
                }
                catch (Exception deleteException)
                {
                    logger.LogError("Failed to clean up meta upload after failure: {deleteException}", deleteException);
                }
            }
            
            throw;
        }
    }
    
    public async Task DeleteImagesFromCloud(string userFolder, IEnumerable<long> imageIds)
    {
        logger.LogTrace("DeleteImageFromCloud({userFolder}, {imageIds})", userFolder, imageIds);

        var keys = imageIds.SelectMany<long, string>(id =>
        [
            $"{userFolder}/{id}/image.png",
            $"{userFolder}/{id}/commands.json",
            $"{userFolder}/{id}/meta.json"
        ]);

        await objectStorageHandler.DeleteFilesFromBucket(_bucketName, keys);
    }
}