using TypoImageGen.Config;
using TypoImageGen.Grpc;
using TypoImageGen.Service;

namespace TypoImageGen;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddGrpc();
        builder.Services.AddHttpClient();
        builder.Services.AddLogging();
        builder.Services.AddScoped<CachedFileProvider>();
        builder.Services.AddScoped<ComboImageGenerator>();
        builder.Services.Configure<ImageGeneratorConfig>(builder.Configuration.GetSection("ImageGenerator"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<ImageGeneratorService>();
        app.MapGet("/",
            () =>
                "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }
}