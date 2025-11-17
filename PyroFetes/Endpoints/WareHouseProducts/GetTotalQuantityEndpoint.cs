using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.WareHouseProduct.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.WareHouseProducts;

public class GetTotalQuantityRequest
{
    public int ProductId { get; set; }
}

public class GetTotalQuantityEndpoint(PyroFetesDbContext database) : Endpoint<GetTotalQuantityRequest, GetTotalQuantityDto>
{
    public override void Configure()
    {
        Get("/api/wareHouseProduct/{@ProductId}", x => new { x.ProductId });
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GetTotalQuantityRequest req, CancellationToken ct)
    {
        bool exists = await database.WarehouseProducts
            .AnyAsync(wp => wp.ProductId == req.ProductId, ct);

        if (!exists)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        int totalQuantity = await database.WarehouseProducts
            .Where(wp => wp.ProductId == req.ProductId)
            .SumAsync(wp => wp.Quantity, ct);

        GetTotalQuantityDto responseDto = new()
        {
            ProductId = req.ProductId,
            TotalQuantity = totalQuantity
        };
        await Send.OkAsync(responseDto, ct);
    }
}