using System.Globalization;
using tobeh.TypoImageGen.Server.Config;
using tobeh.TypoImageGen.Server.Grpc;
using tobeh.TypoImageGen.Server.Service;
using tobeh.Valmar.Client.Util;

namespace tobeh.TypoImageGen.Server;

public class Program
{
    public static void Main(string[] args)
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddGrpc();
        builder.Services.AddHttpClient();
        builder.Services.AddLogging();
        builder.Services.AddValmarGrpc(
            builder.Configuration.GetRequiredSection("Grpc").GetValue<string>("ValmarAddress") ??
            throw new ArgumentException("No Valmar URL provided"));
        builder.Services.AddScoped<CachedFileProvider>();
        builder.Services.AddScoped<ComboImageGenerator>();
        builder.Services.AddScoped<CardImageGenerator>();
        builder.Services.Configure<ImageGeneratorConfig>(builder.Configuration.GetSection("ImageGenerator"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<ImageGeneratorGrpcService>();
        app.MapGet("/",
            () =>
                "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }
}