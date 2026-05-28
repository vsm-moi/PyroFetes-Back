using FastEndpoints;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Prices;

namespace PyroFetes.Endpoints.Suppliers;

public class DeletePriceRequest
{
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
}

public class DeleteProductToSupplierEndpoint(PricesRepository pricesRepository) : Endpoint<DeletePriceRequest>
{
    public override void Configure()
    {
        Delete("/suppliers/{@SupplierId}/{@Product}", x => new { x.SupplierId, x.ProductId });
        Roles("Admin");
    }

    public override async Task HandleAsync(DeletePriceRequest req, CancellationToken ct)
    {
        Price? price = await pricesRepository.SingleOrDefaultAsync(new GetPriceByProductIdAndSupplierIdSpec(req.ProductId, req.SupplierId), ct);

        if (price is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await pricesRepository.DeleteAsync(price, ct);
        await Send.NoContentAsync(ct);
    }
}