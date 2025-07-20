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
        
        await WriteFile(requestStream, false);
        return new Empty();
    }

    public override async Task<Empty> ReplaceFile(IAsyncStreamReader<AddFileMessage> requestStream, ServerCallContext context)
    {
        logger.LogTrace("ReplaceFile()");
        
        await WriteFile(requestStream, true);
        return new Empty();
    }

    private async Task WriteFile(IAsyncStreamReader<AddFileMessage> requestStream, bool overwrite)
    {
        logger.LogTrace("WriteFile()");
        
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
            FileType.EventSprite => "sprites/event",
            FileType.Scene => "scenes",
            FileType.Award => "awards",
            _ => throw new ArgumentOutOfRangeException()
        };
        
        gitHandler.WriteFile(chunkBytes.Data, fileInformation.Name, repoPath, $"Add {fileInformation.Type}: {fileInformation.Name}", overwrite);
    }
}