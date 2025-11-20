using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Prices;

namespace PyroFetes.Endpoints.Prices;

public class DeletePriceRequest
{
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
}

public class DeletePriceEndpoint(PricesRepository pricesRepository) : Endpoint<DeletePriceRequest>
{
    public override void Configure()
    {
        Delete("/api/prices/{@ProductId}/{@SupplierId}", x => new {x.ProductId, x.SupplierId});
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeletePriceRequest req, CancellationToken ct)
    {
        Price? price = await pricesRepository.FirstOrDefaultAsync(new GetPriceByProductIdAndSupplierIdSpec(req.ProductId,req.SupplierId), ct);

        if (price == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        await  pricesRepository.DeleteAsync(price, ct);
        
        await Send.NoContentAsync(ct);
    }
}