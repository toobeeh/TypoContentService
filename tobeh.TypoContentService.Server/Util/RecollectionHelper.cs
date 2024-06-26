namespace tobeh.TypoContentService.Server.Util;

public record RecollectedFileChunk(byte[] Data, string FileName);
public static class RecollectionHelper
{
    public static RecollectedFileChunk RecollectFileChunk(List<FileChunkMessage> fileChunkMessages)
    {
        string? filename = null;
        string? extension = null;
        Dictionary<int, byte[]> chunks = new();

        int maxChunk = 0;

        foreach(var chunk in fileChunkMessages)
        {
            if (filename is null)
            {
                filename = chunk.Name;
            }
            else if(filename != chunk.Name)
            {
                throw new InvalidOperationException("Inonsistent file name.");
            }
            
            if(extension is null)
            {
                extension = chunk.FileType;
            }
            else if(extension != chunk.FileType)
            {
                throw new InvalidOperationException("Inonsistent file extension.");
            }
            
            chunks.Add(chunk.ChunkIndex, chunk.Chunk.ToByteArray());
            maxChunk = Math.Max(maxChunk, chunk.ChunkIndex);
        }

        if (filename is null) throw new InvalidOperationException("No filename provided");
        if (extension is null) throw new InvalidOperationException("No file extension provided");
        var resultFileName = $"{filename}.{extension}";
        
        if(chunks.Count != maxChunk + 1)
        {
            throw new InvalidOperationException("Missing chunks.");
        }

        var combinedChunks = chunks.ToList()
            .OrderBy(chunk => chunk.Key)
            .SelectMany(chunk => chunk.Value)
            .ToArray();

        var result = new RecollectedFileChunk(combinedChunks, resultFileName);

        return result;
    }
}