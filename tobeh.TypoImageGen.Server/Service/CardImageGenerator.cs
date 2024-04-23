using System.Text;
using Google.Protobuf;
using Microsoft.Extensions.Options;
using SkiaSharp;
using Svg.Skia;
using tobeh.TypoImageGen.Server.Config;
using tobeh.TypoImageGen.Server.Util;
using tobeh.Valmar;

namespace tobeh.TypoImageGen.Server.Service;

public class CardImageGenerator(
    ILogger<CardImageGenerator> logger, 
    ComboImageGenerator comboImageGenerator, 
    CachedFileProvider cachedFileProvider, 
    Card.CardClient cardClient, 
    Inventory.InventoryClient inventoryClient,
    IOptions<ImageGeneratorConfig> options)
{
    
    public async Task<List<FileChunkMessage>> GenerateCardImage(GenerateCardMessage request)
    {
        logger.LogTrace("GenerateCardImage(request={request})", request);

        // load config and template
        var cardConfig = await cardClient.GetMemberCardSettingsAsync(new GetMemberCardSettingsMessage
            { Login = request.SettingsOwnerLogin });
        var cardTemplate =
            await cardClient.GetCardTemplateAsync(new GetCardTemplateMessage { Name = cardConfig.TemplateName });
        
        // get combo image and convert to base64
        var comboImage = RecollectionHelper.RecollectFileChunk(await comboImageGenerator.GenerateComboFromSprites(request.Combo));
        var comboBase64 = Convert.ToBase64String(comboImage.Data);
        
        // get user profile picture and convert to base64
        var profileImage = await cachedFileProvider.GetBytesFromUrl(request.ProfileImageUrl);
        var profileBase64 = Convert.ToBase64String(profileImage);
        
        // get background image and convert to base64
        var imgurLink = $"https://i.imgur.com/{cardConfig.BackgroundImage ?? "qFmcbT0.png"}";
        var background = await cachedFileProvider.GetBytesFromUrl(imgurLink);
        var backgroundBase64 = Convert.ToBase64String(background);

        var styleInjection = $@"
            {cardTemplate.TemplateCss}
             #header, #border {{ stroke:{(cardConfig.HeaderOpacity >= 1 ? cardConfig.HeaderColor : "none") }}} 
             #header {{ fill: {cardConfig.HeaderColor}; {(cardConfig.HeaderOpacity < 1 ? ("opacity:" + cardConfig.HeaderOpacity) : "") }}} 
             * {{font-style:'Roboto' !important}} 
        ";
        
        if(!request.IsPatron) styleInjection += " #patron * {opacity: .5} ";
        if(!request.IsEarlyUser) styleInjection += " #early * {opacity: .5} ";
        if(!request.IsModerator) styleInjection += " #moderator * {opacity: .5} ";
        
        if(request.Username.Length > 15) request.Username = request.Username[..15] + "..";
        
        var svgCode = cardTemplate.Template
            .Replace("$username$", request.Username)
            .Replace("$bubbles$", $"{request.Bubbles} Bubbles")
            .Replace("$drops$", $"{request.Drops} Drops")
            .Replace("$dropratio$", $" {request.DropRatio :0.#}: {GetRatioName(request.DropRatio)}")
            .Replace("$firstseen$", request.FirstSeen)
            .Replace("$sprites$", $" {request.SpritesCount} bought")
            .Replace("$events$", request.EventsParticipated.ToString())
            .Replace("$hours$", $" {request.Bubbles / 6 / 60 :0} hours")
            .Replace("$brank$", $" #{request.BubbleRank}")
            .Replace("$drank$", $" #{request.DropRank}")
            .Replace("$servers$", request.ServersConnected.ToString())
            .Replace("$lighttext$", cardConfig.LightTextColor)
            .Replace("$darktext$", cardConfig.DarkTextColor)
            .Replace("$bgopacity$", $"{cardConfig.BackgroundOpacity :0.##}")
            .Replace("$bgheight$", "328")
            .Replace("$profilebase64$", profileBase64)
            .Replace("$bgbase64$", backgroundBase64)
            .Replace("$spritebase64$", comboBase64)
            .Replace("$customstyle$", styleInjection);

        var svgImage = SKSvg.CreateFromSvg(svgCode);
        
        File.WriteAllText("card.svg", svgCode);
        
        var svgStream = new MemoryStream();
        svgImage.Save(svgStream, SKColor.Empty, SKEncodedImageFormat.Png, 200, 3, 3);
        var bytes = svgStream.ToArray();
        var byteChunks = bytes.Chunk(options.Value.ByteChunkKByte * 1024);
     
        var messages = byteChunks.Select((chunk, index) => new FileChunkMessage
        {
            ChunkIndex = index,
            Chunk = ByteString.CopyFrom(chunk),
            Name = "card",
            FileType = "png"
        }).ToList();

        return messages;
    }

    private string GetRatioName(double ratio)
    {
        return ratio switch
        {
            > 25 => "Black Magic",
            > 20 => "Sovereign",
            > 15 => "Godmode",
            > 12 => "Legendary",
            > 10 => "Epic",
            > 8 => "Expert",
            > 5 => "Capable",
            > 3 => "Ambitious",
            > 2 => "Relaxed",
            _ => "Newbie"
        };
    }
    
}