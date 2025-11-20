using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.SettingDTO.Request;
using PyroFetes.DTO.SettingDTO.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Settings;

namespace PyroFetes.Endpoints.Settings;

public class PatchSettingLogoEndpoint(
    SettingsRepository settingsRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchSettingLogoDto, GetSettingDto>
{
    public override void Configure()
    {
        Patch("/settings/{@Id}/logo", x => new {x.Id});
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(PatchSettingLogoDto req, CancellationToken ct)
    {
        Setting? setting = await settingsRepository.FirstOrDefaultAsync(new GetSettingByIdSpec(req.Id), ct);

        if (setting == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        setting.Logo = req.Logo;
        await settingsRepository.UpdateAsync(setting, ct);
        
        await Send.OkAsync(mapper.Map<GetSettingDto>(setting), ct);
    }
}