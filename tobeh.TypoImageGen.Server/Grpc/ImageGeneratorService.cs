using Grpc.Core;
using tobeh.TypoImageGen.Server.Service;

namespace tobeh.TypoImageGen.Server.Grpc;

public class ImageGeneratorService(
    ILogger<ImageGeneratorService> logger,
    ComboImageGenerator comboImageGenerator
) : ImageGenerator.ImageGeneratorBase
{
    public override async Task GenerateComboFromUrls(GenerateComboFromUrlsMessage request, IServerStreamWriter<GeneratedImageMessage> responseStream,
        ServerCallContext context)
    {
        logger.LogTrace("GenerateComboFromUrls(request={request})", request);

        var chunks = await comboImageGenerator.GenerateComboFromUrls(request);
        foreach (var chunk in chunks)
        {
            await responseStream.WriteAsync(chunk);
        }
    }
}