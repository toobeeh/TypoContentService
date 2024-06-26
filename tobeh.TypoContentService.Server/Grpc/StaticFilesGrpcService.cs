using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using tobeh.TypoContentService.Server.Service;
using tobeh.TypoContentService.Server.Util;

namespace tobeh.TypoContentService.Server.Grpc;

public class StaticFilesGrpcService(
    ILogger<StaticFilesGrpcService> logger,
    GitHandler gitHandler
) : StaticFiles.StaticFilesBase
{
    public override async Task<Empty> AddFile(IAsyncStreamReader<AddFileMessage> requestStream, ServerCallContext context)
    {
        logger.LogTrace("AddFile()");
        
        List<FileChunkMessage> chunks = new();
        FileInformationMessage? fileInformation = null;

        await requestStream.ProcessAllAsync(data =>
        {
            if (data.DataCase == AddFileMessage.DataOneofCase.FileChunk) chunks.Add(data.FileChunk);
            else if (data.DataCase == AddFileMessage.DataOneofCase.FileInformation)
                fileInformation = data.FileInformation;
        });
        
        if(fileInformation is null) throw new RpcException(new Status(StatusCode.InvalidArgument, "FileInformation is missing"));
        if(chunks.Count == 0) throw new RpcException(new Status(StatusCode.InvalidArgument, "No chunks received"));

        var chunkBytes = RecollectionHelper.RecollectFileChunk(chunks);
        var repoPath = fileInformation.Type switch
        {
            FileType.Drop => "drops",
            FileType.Sprite => "sprites/regular",
            FileType.EventSprite => "sprite/event",
            FileType.Scene => "scenes",
            _ => throw new ArgumentOutOfRangeException()
        };
        
        gitHandler.AddFile(chunkBytes.Data, fileInformation.Name, repoPath, $"Add {fileInformation.Type}: {fileInformation.Name}");
        return new Empty();
    }
}