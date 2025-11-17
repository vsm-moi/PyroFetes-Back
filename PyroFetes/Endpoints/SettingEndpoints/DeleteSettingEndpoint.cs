using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Endpoints.SettingEndpoints;

public class DeleteSettingRequest
{
    public int Id { get; set; }
}

public class DeleteSettingEndpoint(PyroFetesDbContext database) : Endpoint<DeleteSettingRequest>
{
    public override void Configure()
    {
        Delete("/api/setting/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(DeleteSettingRequest req, CancellationToken ct)
    {
        var setting = await database.Settings.SingleOrDefaultAsync(x => x.Id == req.Id, ct);

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