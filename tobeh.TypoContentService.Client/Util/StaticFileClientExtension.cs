using tobeh.TypoContentService;
using tobeh.TypoContentService.Client.Util;

namespace tobeh.TypoContentService;

public partial class StaticFiles
{
    public partial class StaticFilesClient
    {
        public async Task AddFileFromBytes(byte[] bytes, string name, string extension)
        {
            var messages = FileChunkCollectorExtension
                .CreateByteChunks(bytes, name, extension)
                .Select(chunk => new AddFileMessage { FileChunk = chunk})
                .ToList();

            messages.Add(new AddFileMessage { FileInformation = new FileInformationMessage
            {
                Name = $"{name}.{extension}",
                Type = FileType.Drop
            }});

            var stream = AddFile().RequestStream;
            foreach (var message in messages)
            {
                await stream.WriteAsync(message);
            }
            await stream.CompleteAsync();
        }
    }
}