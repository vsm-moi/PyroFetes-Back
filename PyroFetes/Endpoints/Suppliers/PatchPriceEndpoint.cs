using FastEndpoints;
using PyroFetes.DTO.Price.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Prices;

namespace PyroFetes.Endpoints.Suppliers;

public class PatchPriceEndpoint(
    PricesRepository pricesRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchPriceSellingPriceDto>
{
    public override void Configure()
    {
        Patch("/prices/{@ProductId}/{@SupplierId}/SellingPrice", x => new { x.ProductId, x.SupplierId });
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(PatchPriceSellingPriceDto req, CancellationToken ct)
    {
        Price? price = await pricesRepository.SingleOrDefaultAsync(new GetPriceByProductIdAndSupplierIdSpec(req.ProductId, req.SupplierId), ct);

        if (price is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        mapper.Map(req, price);

        await pricesRepository.SaveChangesAsync(ct);
        await Send.NoContentAsync(ct);
    }
}