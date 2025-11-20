using FastEndpoints;
using PyroFetes.DTO.SettingDTO.Request;
using PyroFetes.DTO.SettingDTO.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Settings;

public class CreateSettingEndpoint(
    SettingsRepository settingsRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreateSettingDto, GetSettingDto>
{
    public override void Configure()
    {
        Post("/api/setting");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateSettingDto req, CancellationToken ct)
    {
        Setting setting = new Setting()
        {
            ElectronicSignature = req.ElectronicSignature,
            Logo = req.Logo
        };
        
        await settingsRepository.AddAsync(setting, ct);

        await Send.OkAsync(mapper.Map<GetSettingDto>(setting), ct);
    }
}