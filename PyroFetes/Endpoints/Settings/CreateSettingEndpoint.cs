using FastEndpoints;
using PyroFetes.DTO.SettingDTO.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Settings;

public class CreateSettingEndpoint(SettingsRepository settingsRepository) : Endpoint<CreateSettingDto>
{
    public override void Configure()
    {
        Post("/settings");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateSettingDto req, CancellationToken ct)
    {
        // Encodage en base64
        using MemoryStream memoryStream = new();
        if (req.Logo != null) await req.Logo.CopyToAsync(memoryStream, ct);
        byte[] logoBytes = memoryStream.ToArray();

        if (req.ElectronicSignature != null) await req.ElectronicSignature.CopyToAsync(memoryStream, ct);
        byte[] signatureBytes = memoryStream.ToArray();

        Setting setting = new()
        {
            ElectronicSignature = Convert.ToBase64String(signatureBytes),
            Logo = Convert.ToBase64String(logoBytes)
        };

        await settingsRepository.AddAsync(setting, ct);
        await Send.NoContentAsync(ct);
    }
}