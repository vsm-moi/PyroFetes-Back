using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.SettingDTO.Request;
using PyroFetes.DTO.SettingDTO.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Settings;

public class PatchSettingLogoEndpoint(PyroFetesDbContext database) : Endpoint<PatchSettingLogoDto, GetSettingDto>
{
    public override void Configure()
    {
        Patch("/api/setting/{@Id}/Logo", x => new {x.Id});
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(PatchSettingLogoDto req, CancellationToken ct)
    {
        Setting? setting = await database.Settings.SingleOrDefaultAsync(x => x.Id == req.Id, ct);

        if (setting == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        setting.Logo = req.Logo;
        await database.SaveChangesAsync(ct);

        GetSettingDto responseDto = new()
        {
            Id = setting.Id,
            ElectronicSignature = setting.ElectronicSignature,
            Logo = setting.Logo
        };
        
        await Send.OkAsync(responseDto, ct);
    }
}