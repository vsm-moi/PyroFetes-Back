using FastEndpoints;
using PyroFetes.DTO.SettingDTO.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Settings;

namespace PyroFetes.Endpoints.Settings;

public class GetSettingRequest
{
    public int Id { get; set; }
}

public class GetSettingEndpoint(
    SettingsRepository settingsRepository,
    AutoMapper.IMapper mapper) : Endpoint<GetSettingRequest, GetSettingDto>
{
    public override void Configure()
    {
        Get("/settings/{@Id}", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetSettingRequest req, CancellationToken ct)
    {
        Setting? setting = await settingsRepository.SingleOrDefaultAsync(new GetSettingByIdSpec(req.Id), ct);

        if (setting is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await Send.OkAsync(mapper.Map<GetSettingDto>(setting), ct);
    }
}