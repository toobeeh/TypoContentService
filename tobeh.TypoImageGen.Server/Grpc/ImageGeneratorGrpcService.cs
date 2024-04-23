using Grpc.Core;
using tobeh.TypoImageGen.Server.Service;

namespace tobeh.TypoImageGen.Server.Grpc;

public class ImageGeneratorGrpcService(
    ILogger<ImageGeneratorGrpcService> logger,
    ComboImageGenerator comboImageGenerator,
    CardImageGenerator cardImageGenerator
) : ImageGenerator.ImageGeneratorBase
{
    public override async Task GenerateSpriteCombo(GenerateComboMessage request, IServerStreamWriter<FileChunkMessage> responseStream, ServerCallContext context)
    {
        logger.LogTrace("GenerateSpriteCombo(request={request})", request);

        var chunks = await comboImageGenerator.GenerateComboFromSprites(request);
        foreach (var chunk in chunks)
        {
            await responseStream.WriteAsync(chunk);
        }
    }

    public override async Task GenerateCard(GenerateCardMessage request, IServerStreamWriter<FileChunkMessage> responseStream, ServerCallContext context)
    {
        logger.LogTrace("GenerateCard(request={request})", request);

        var chunks = await cardImageGenerator.GenerateCardImage(request);
        foreach (var chunk in chunks)
        {
            await responseStream.WriteAsync(chunk);
        }
    }
}