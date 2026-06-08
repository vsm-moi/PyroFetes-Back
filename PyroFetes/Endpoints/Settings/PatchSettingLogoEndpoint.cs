using FastEndpoints;
using PyroFetes.DTO.SettingDTO.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Services;

namespace PyroFetes.Endpoints.Settings;

public class PatchSettingLogoEndpoint(SettingsRepository settingsRepository, StorageService storageService) : Endpoint<PatchSettingLogoDto>
{
    public override void Configure()
    {
        Patch("/settings/logo");
        AllowFormData();
        Roles("Admin");
    }

    public override async Task HandleAsync(PatchSettingLogoDto req, CancellationToken ct)
    {
        Setting? setting = await settingsRepository.FirstOrDefaultAsync(ct);

        if (setting is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        string key = await storageService.UploadFile(req.Logo!, "logo", ct);

        setting.Logo = key;

        await settingsRepository.SaveChangesAsync(ct);
        await Send.NoContentAsync(ct);
    }
}