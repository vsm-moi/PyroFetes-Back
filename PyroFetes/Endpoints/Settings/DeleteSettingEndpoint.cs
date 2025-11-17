using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Settings;

public class DeleteSettingRequest
{
    public int Id { get; set; }
}

public class DeleteSettingEndpoint(PyroFetesDbContext database) : Endpoint<DeleteSettingRequest>
{
    public override void Configure()
    {
        Delete("/api/setting/{@Id}", x => new {x.Id});
    }
    
    public override async Task HandleAsync(DeleteSettingRequest req, CancellationToken ct)
    {
        Setting? setting = await database.Settings.SingleOrDefaultAsync(x => x.Id == req.Id, ct);

        if (setting == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        database.Settings.Remove(setting);
        await database.SaveChangesAsync(ct);
        
        await Send.NoContentAsync(ct);
    }
}