using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Deliverers;

public class DeleteDelivererRequest
{
    public int DelivererId { get; set; }
}
public class DeleteDelivererEndpoint(PyroFetesDbContext database) : Endpoint<DeleteDelivererRequest>
{
    public override void Configure()
    {
        Delete("api/deliverers/{@id}", x=>new {x.DelivererId});
        AllowAnonymous();

    }

    public override async Task HandleAsync(DeleteDelivererRequest req, CancellationToken ct)
    {
        Deliverer? deliverer = await database.Deliverers.SingleOrDefaultAsync(x=>x.Id == req.DelivererId, ct);

        if (deliverer == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        database.Remove(deliverer);
        
        await database.SaveChangesAsync(ct);

        await Send.OkAsync(ct);
    }

}