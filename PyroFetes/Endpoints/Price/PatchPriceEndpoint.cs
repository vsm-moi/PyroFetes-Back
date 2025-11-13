using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Price.Request;
using PyroFetes.DTO.Price.Response;

namespace PyroFetes.Endpoints.Price;

public class PatchPriceEndpoint(PyroFetesDbContext database) : Endpoint<PatchPriceSellingPriceDto, GetPriceDto>
{
    public override void Configure()
    {
        Patch("/api/prices/{@ProductId}/{@SupplierId}/SellingPrice", x => new { x.ProductId, x.SupplierId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchPriceSellingPriceDto req, CancellationToken ct)
    {
        var price = await database.Prices.SingleOrDefaultAsync(p => p.ProductId == req.ProductId && p.SupplierId == req.SupplierId, ct);
        if (price == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        price.SellingPrice = req.SellingPrice;
        await database.SaveChangesAsync(ct);

        GetPriceDto responseDto = new()
        {
            ProductId = price.ProductId,
            SupplierId = price.SupplierId,
            SellingPrice = price.SellingPrice
        };
        await Send.OkAsync(responseDto, ct);
    }
}