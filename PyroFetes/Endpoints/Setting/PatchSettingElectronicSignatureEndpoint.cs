using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.SettingDTO.Request;
using PyroFetes.DTO.SettingDTO.Response;

namespace PyroFetes.Endpoints.Setting;

public class PatchSettingElectronicSignatureEndpoint(PyroFetesDbContext database) : Endpoint<PatchSettingElectronicSignatureDto, GetSettingDto>
{
    public override void Configure()
    {
        Get("/api/setting/{@Id}/ElectronicSignature", x => new {x.Id});
    }
    
    public override async Task HandleAsync(PatchSettingElectronicSignatureDto req, CancellationToken ct)
    {
        var setting = await database.Settings.SingleOrDefaultAsync(x => x.Id == req.Id, ct);

        if (setting == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        setting.ElectronicSignature = req.ElectronicSignature;
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