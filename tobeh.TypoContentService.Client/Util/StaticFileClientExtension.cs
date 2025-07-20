using tobeh.TypoContentService;
using tobeh.TypoContentService.Client.Util;

namespace tobeh.TypoContentService;

public partial class StaticFiles
{
    public partial class StaticFilesClient
    {
        public async Task WriteFileFromBytes(byte[] bytes, string name, string extension, FileType type, bool overwrite = false)
        {
            var messages = FileChunkCollectorExtension
                .CreateByteChunks(bytes, name, extension)
                .Select(chunk => new AddFileMessage { FileChunk = chunk})
                .ToList();

            messages.Add(new AddFileMessage { FileInformation = new FileInformationMessage
            {
                Name = $"{name}.{extension}",
                Type = type
            }});

            var stream = overwrite ? ReplaceFile().RequestStream : AddFile().RequestStream;
            foreach (var message in messages)
            {
                await stream.WriteAsync(message);
            }
            await stream.CompleteAsync();
        }
    }
}