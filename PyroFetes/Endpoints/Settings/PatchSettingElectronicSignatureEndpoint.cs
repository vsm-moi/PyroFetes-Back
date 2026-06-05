using FastEndpoints;
using PyroFetes.DTO.SettingDTO.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Services;

namespace PyroFetes.Endpoints.Settings;

public class PatchSettingElectronicSignatureEndpoint(SettingsRepository settingsRepository, StorageService storageService) : Endpoint<PatchSettingElectronicSignatureDto>
{
    public override void Configure()
    {
        Patch("/settings/electronicSignature");
        AllowFormData();
        Roles("Admin");

    }

    public override async Task HandleAsync(PatchSettingElectronicSignatureDto req, CancellationToken ct)
    {
        Setting? setting = await settingsRepository.FirstOrDefaultAsync(ct);

        if (setting is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        string key = await storageService.UploadFile(req.ElectronicSignature!, "electronicSignature", ct);
        setting.ElectronicSignature = key;
        
        await settingsRepository.SaveChangesAsync(ct);
        await Send.NoContentAsync(ct);
    }
}