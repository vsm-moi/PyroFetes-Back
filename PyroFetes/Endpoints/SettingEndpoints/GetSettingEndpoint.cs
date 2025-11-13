using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.SettingDTO.Response;

namespace PyroFetes.Endpoints.SettingEndpoints;

public class GetSettingRequest
{
    public int Id { get; set; }
}

public class GetSettingEndpoint(PyroFetesDbContext database) : Endpoint<GetSettingRequest, GetSettingDto>
{
    public override void Configure()
    {
        Get("/api/setting/{@Id}", x => new {x.Id});
    }
    
    public override async Task HandleAsync(GetSettingRequest req, CancellationToken ct)
    {
        var setting = await database.Settings
            .SingleOrDefaultAsync(x => x.Id == req.Id, ct);

        if (setting == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        GetSettingDto responseDto = new()
        {
            Id = setting.Id,
            ElectronicSignature = setting.ElectronicSignature,
            Logo = setting.Logo
        };
        await Send.OkAsync(responseDto, ct);
    }
}