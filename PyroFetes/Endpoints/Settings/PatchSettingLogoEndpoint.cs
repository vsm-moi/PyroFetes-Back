using FastEndpoints;
using PyroFetes.DTO.SettingDTO.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Settings;

public class PatchSettingLogoEndpoint(SettingsRepository settingsRepository) : Endpoint<PatchSettingLogoDto>
{
    public override void Configure()
    {
        Patch("/settings/logo");
        AllowFormData();
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchSettingLogoDto req, CancellationToken ct)
    {
        Setting? setting = await settingsRepository.FirstOrDefaultAsync(ct);

        if (setting is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        // Encodage en base64
        using MemoryStream memoryStream = new();
        if (req.Logo != null) await req.Logo.CopyToAsync(memoryStream, ct);
        byte[] logoBytes = memoryStream.ToArray();

        setting.Logo = Convert.ToBase64String(logoBytes);

        await settingsRepository.SaveChangesAsync(ct);
        await Send.NoContentAsync(ct);
    }
}