using FastEndpoints;
using PyroFetes.DTO.SettingDTO.Request;
using PyroFetes.DTO.SettingDTO.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Settings;

public class CreateSettingEndpoint(PyroFetesDbContext database) : Endpoint<CreateSettingDto, GetSettingDto>
{
    public override void Configure()
    {
        Post("/api/setting");
    }

    public override async Task HandleAsync(CreateSettingDto req, CancellationToken ct)
    {
        Setting setting = new Setting()
        {
            ElectronicSignature = req.ElectronicSignature,
            Logo = req.Logo
        };
        
        database.Settings.Add(setting);
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