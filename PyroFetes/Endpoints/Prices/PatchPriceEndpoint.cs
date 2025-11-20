using FastEndpoints;
using PyroFetes.DTO.Price.Request;
using PyroFetes.DTO.Price.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Prices;

namespace PyroFetes.Endpoints.Prices;

public class PatchPriceEndpoint(
    PricesRepository pricesRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchPriceSellingPriceDto, GetPriceDto>
{
    public override void Configure()
    {
        Patch("/prices/{@ProductId}/{@SupplierId}/SellingPrice", x => new { x.ProductId, x.SupplierId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchPriceSellingPriceDto req, CancellationToken ct)
    {
        Price? price = await pricesRepository.FirstOrDefaultAsync(new GetPriceByProductIdAndSupplierIdSpec(req.ProductId, req.SupplierId),ct);
        
        if (price == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        price.SellingPrice = req.SellingPrice;
        
        await pricesRepository.UpdateAsync(price, ct);
        
        await Send.OkAsync(mapper.Map<GetPriceDto>(price), ct);
    }
}