using Grpc.Core;
using tobeh.TypoImageGen.Server.Service;

namespace tobeh.TypoImageGen.Server.Grpc;

public class ImageGeneratorService(
    ILogger<ImageGeneratorService> logger,
    ComboImageGenerator comboImageGenerator
) : ImageGenerator.ImageGeneratorBase
{
    public override async Task GenerateSpriteCombo(GenerateComboMessage request, IServerStreamWriter<FileChunkMessage> responseStream, ServerCallContext context)
    {
        logger.LogTrace("GenerateSpriteCombo(request={request})", request);

        var chunks = await comboImageGenerator.GenerateComboFromUrls(request);
        foreach (var chunk in chunks)
        {
            await responseStream.WriteAsync(chunk);
        }
    }
}