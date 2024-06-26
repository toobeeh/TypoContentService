using Grpc.Core;

namespace tobeh.TypoContentService.Server.Util;

public static class ClientStreamHelper
{
    public static async Task ProcessAllAsync<T>(this IAsyncStreamReader<T> stream, Action<T> handler) where T : class
    {
        while (await stream.MoveNext())
        {
            var item = stream.Current;
            handler.Invoke(item);
        }
    }
}