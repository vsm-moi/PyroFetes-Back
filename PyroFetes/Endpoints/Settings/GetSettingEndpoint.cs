using FastEndpoints;
using PyroFetes.DTO.SettingDTO.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Settings;

public class GetSettingEndpoint(SettingsRepository settingsRepository, AutoMapper.IMapper mapper) : EndpointWithoutRequest<GetSettingDto>
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

        await Send.OkAsync(mapper.Map<GetSettingDto>(setting), ct);
    }
}