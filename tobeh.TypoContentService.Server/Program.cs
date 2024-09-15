using System.Globalization;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using tobeh.TypoContentService.Server.Config;
using tobeh.TypoContentService.Server.Grpc;
using tobeh.TypoContentService.Server.Service;
using tobeh.Valmar.Client.Util;

namespace tobeh.TypoContentService.Server;

public class Program
{
    public static void Main(string[] args)
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
        
        var builder = WebApplication.CreateBuilder(args);
        
        // configure kestrel
        builder.WebHost.ConfigureKestrel(options =>
        {
            // Setup a HTTP/2 endpoint without TLS.
            options.ListenAnyIP(builder.Configuration.GetRequiredSection("Grpc").GetValue<int>("HostPort"), o => o.Protocols = HttpProtocols.Http2);
        });

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
        builder.Services.AddScoped<GitHandler>();
        builder.Services.AddSingleton<ObjectStorageHandler>();
        builder.Services.AddScoped<CloudService>();
        builder.Services.Configure<ImageGeneratorConfig>(builder.Configuration.GetSection("ImageGenerator"));
        builder.Services.Configure<GitConfig>(builder.Configuration.GetSection("Git"));

        var app = builder.Build();

        // Configure the HTTP request pipeline
        app.MapGrpcService<ImageGeneratorGrpcService>();
        app.MapGrpcService<StaticFilesGrpcService>();
        app.MapGrpcService<ObjectStorageGrpcService>();
        app.MapGet("/",
            () =>
                "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }
}