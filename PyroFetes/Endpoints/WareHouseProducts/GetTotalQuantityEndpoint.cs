using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.WareHouseProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.WarehouseProducts;

namespace PyroFetes.Endpoints.WareHouseProducts;

public class GetTotalQuantityRequest
{
    public int ProductId { get; set; }
}

public class GetTotalQuantityEndpoint(
    WarehouseProductsRepository warehouseProductsRepository) : Endpoint<GetTotalQuantityRequest, GetTotalQuantityDto>
{
    public override void Configure()
    {
        Get("/wareHouseProducts/{@ProductId}", x => new { x.ProductId });
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GetTotalQuantityRequest req, CancellationToken ct)
    {
        bool exists = await warehouseProductsRepository.AnyAsync(new GetWarehouseProductByProductIdSpec(req.ProductId), ct);

        if (!exists)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        int totalQuantity =
            await warehouseProductsRepository.SumAsync(new GetProductTotalQuantitySpec(req.ProductId),
                wp => wp.Quantity, ct); 

        GetTotalQuantityDto responseDto = new()
        {
            ProductId = req.ProductId,
            TotalQuantity = totalQuantity
        };
        await Send.OkAsync(responseDto, ct);
    }
}