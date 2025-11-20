using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.WareHouseProduct.Request;
using PyroFetes.DTO.WareHouseProduct.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.WareHouseProducts;

public class PatchWareHouseProductQuantityEndpoint(PyroFetesDbContext database)
    : Endpoint<PatchWareHouseProductQuantityDto, GetWareHouseProductDto>
{
    public override void Configure()
    {
        Patch("/wareHouseProducts/{@ProductId}/{@WareHouseId}/quantity", x => new { x.ProductId, x.WareHouseId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchWareHouseProductQuantityDto req, CancellationToken ct)
    {
        WarehouseProduct? wareHouseProduct =
            await database.WarehouseProducts.SingleOrDefaultAsync(
                wp => wp.ProductId == req.ProductId && wp.WarehouseId == req.WareHouseId, ct);
        
        if (wareHouseProduct == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        wareHouseProduct.Quantity = req.Quantity;
        await database.SaveChangesAsync(ct);

        GetWareHouseProductDto responseDto = new()
        {
            ProductId = wareHouseProduct.ProductId,
            WareHouseId = wareHouseProduct.WarehouseId,
            Quantity = wareHouseProduct.Quantity
        };
        await Send.OkAsync(responseDto, ct);
    }
}