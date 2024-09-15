using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using tobeh.TypoContentService.Server.Service;
using tobeh.TypoContentService.Server.Util;

namespace tobeh.TypoContentService.Server.Grpc;

public class ObjectStorageGrpcService(
    ILogger<ObjectStorageGrpcService> logger,
    CloudService cloudService
) : ObjectStorage.ObjectStorageBase
{
    public override async Task<Empty> SaveImageToCloud(IAsyncStreamReader<SaveImageToCloudMessage> requestStream, ServerCallContext context)
    {
        logger.LogTrace("SaveImageToCloud({requestStream})", requestStream);
        
        List<FileChunkMessage> imageChunks = new();
        List<FileChunkMessage> commandChunks = new();
        List<FileChunkMessage> metaChunks = new();
        CloudImageIdentificationMessage? fileInformation = null;

        await requestStream.ProcessAllAsync(data =>
        {
            switch (data.DataCase)
            {
                case SaveImageToCloudMessage.DataOneofCase.ImageFileChunk:
                    imageChunks.Add(data.ImageFileChunk);
                    break;
                case SaveImageToCloudMessage.DataOneofCase.CommandsFileChunk:
                    commandChunks.Add(data.CommandsFileChunk);
                    break;
                case SaveImageToCloudMessage.DataOneofCase.MetaFileChunk:
                    metaChunks.Add(data.MetaFileChunk);
                    break;
                case SaveImageToCloudMessage.DataOneofCase.ImageIdentification:
                    fileInformation = data.ImageIdentification;
                    break;
            }
        });
        
        if(fileInformation is null) throw new RpcException(new Status(StatusCode.InvalidArgument, "FileInformation is missing"));
        if (imageChunks.Count == 0) throw new RpcException(new Status(StatusCode.InvalidArgument, "No image chunks received"));
        if (commandChunks.Count == 0) throw new RpcException(new Status(StatusCode.InvalidArgument, "No command chunks received"));
        if (metaChunks.Count == 0) throw new RpcException(new Status(StatusCode.InvalidArgument, "No meta chunks received"));
        
        var imageBytes = RecollectionHelper.RecollectFileChunk(imageChunks);
        var commandBytes = RecollectionHelper.RecollectFileChunk(commandChunks);
        var metaBytes = RecollectionHelper.RecollectFileChunk(metaChunks);
        
        await cloudService.UploadImageToCloud(imageBytes.Data, commandBytes.Data, metaBytes.Data, fileInformation.UserFolder, fileInformation.ImageId);

        return new Empty();
    }

    public override async Task<Empty> DeleteImageFromCloud(CloudImageIdentificationMessage request, ServerCallContext context)
    {
        return await base.DeleteImageFromCloud(request, context);
    }
}