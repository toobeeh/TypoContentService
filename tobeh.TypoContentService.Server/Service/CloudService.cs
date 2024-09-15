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
                    await objectStorageHandler.DeleteFileFromBucket(_bucketName, imagePath);
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
                    await objectStorageHandler.DeleteFileFromBucket(_bucketName, commandsPath);
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
                    await objectStorageHandler.DeleteFileFromBucket(_bucketName, metaPath);
                }
                catch (Exception deleteException)
                {
                    logger.LogError("Failed to clean up meta upload after failure: {deleteException}", deleteException);
                }
            }
            
            throw;
        }
    }
    
    public async Task DeleteImageFromCloud(string userFolder, long imageId)
    {
        logger.LogTrace("DeleteImageFromCloud({userFolder}, {imageId})", userFolder, imageId);

        try
        {
            await objectStorageHandler.DeleteFileFromBucket(_bucketName, $"{userFolder}/{imageId}/image.png");
            await objectStorageHandler.DeleteFileFromBucket(_bucketName, $"{userFolder}/{imageId}/commands.json");
            await objectStorageHandler.DeleteFileFromBucket(_bucketName, $"{userFolder}/{imageId}/meta.json");
        }
        catch (Exception e)
        {
            logger.LogError("Failed to delete image {folder}, {id}) from cloud: {e}", userFolder, imageId, e);
            throw;
        }
    }
}