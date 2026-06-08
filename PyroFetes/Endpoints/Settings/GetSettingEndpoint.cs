using FastEndpoints;
using PyroFetes.DTO.SettingDTO.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Services;

namespace PyroFetes.Endpoints.Settings;

public class GetSettingEndpoint(SettingsRepository settingsRepository, StorageService storageService) : EndpointWithoutRequest<GetSettingDto>
{
    public override void Configure()
    {
        Get("/settings/");
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        Setting? setting = await settingsRepository.FirstOrDefaultAsync(ct);

        if (setting is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        GetSettingDto settingDto = new()
        {
            Id = setting.Id,
            ElectronicSignature = storageService.GetUrl(setting.ElectronicSignature!),
            Logo = storageService.GetUrl(setting.Logo!)
        };

        await Send.OkAsync(settingDto, ct);
    }
}