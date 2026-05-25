using FastEndpoints;
using PyroFetes.DTO.SettingDTO.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Settings;

public class PatchSettingElectronicSignatureEndpoint(SettingsRepository settingsRepository) : Endpoint<PatchSettingElectronicSignatureDto>
{
    public override void Configure()
    {
        Patch("/settings/electronicSignature");
        AllowFormData();
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchSettingElectronicSignatureDto req, CancellationToken ct)
    {
        Setting? setting = await settingsRepository.FirstOrDefaultAsync(ct);

        if (setting is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        // Encodage en base64
        using MemoryStream memoryStream = new();
        if (req.ElectronicSignature != null) await req.ElectronicSignature.CopyToAsync(memoryStream, ct);
        byte[] signatureBytes = memoryStream.ToArray();

        setting.ElectronicSignature = Convert.ToBase64String(signatureBytes);

        await settingsRepository.SaveChangesAsync(ct);
        await Send.NoContentAsync(ct);
    }
}