using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Settings;

namespace PyroFetes.Endpoints.Settings;

public class DeleteSettingRequest
{
    public int Id { get; set; }
}

public class DeleteSettingEndpoint(SettingsRepository settingsRepository) : Endpoint<DeleteSettingRequest>
{
    public override void Configure()
    {
        Delete("/api/setting/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(DeleteSettingRequest req, CancellationToken ct)
    {
        Setting? setting = await settingsRepository.FirstOrDefaultAsync(new GetSettingByIdSpec(req.Id), ct);

        if (setting == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        await settingsRepository.DeleteAsync(setting, ct);
        
        await Send.NoContentAsync(ct);
    }
}