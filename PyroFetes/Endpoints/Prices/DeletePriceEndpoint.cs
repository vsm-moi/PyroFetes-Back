using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Prices;

public class DeletePriceRequest
{
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
}

public class DeletePriceEndpoint(PyroFetesDbContext database) : Endpoint<DeletePriceRequest>
{
    public override void Configure()
    {
        Delete("/api/prices/{@ProductId}/{@SupplierId}", x => new {x.ProductId, x.SupplierId});
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeletePriceRequest req, CancellationToken ct)
    {
        Price? price = await database.Prices
            .SingleOrDefaultAsync(p => p.ProductId == req.ProductId && p.SupplierId == req.SupplierId, ct);

        if (price == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        database.Prices.Remove(price); 
        await database.SaveChangesAsync(ct);
        
        await Send.NoContentAsync(ct);
    }
}