using FastEndpoints;
using PyroFetes.DTO.WareHouseProduct.Request;
using PyroFetes.DTO.WareHouseProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.WarehouseProducts;

namespace PyroFetes.Endpoints.WareHouseProducts;

public class PatchWareHouseProductQuantityEndpoint(WarehouseProductsRepository warehouseProductsRepository) : Endpoint<PatchWareHouseProductQuantityDto, GetWareHouseProductDto>
{
    public override void Configure()
    {
        Patch("/wareHouseProducts/{@ProductId}/{@WareHouseId}/quantity", x => new { x.ProductId, x.WareHouseId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchWareHouseProductQuantityDto req, CancellationToken ct)
    {
        WarehouseProduct? wareHouseProduct = await warehouseProductsRepository.FirstOrDefaultAsync(new GetWarehouseProductByProductIdSpec(req.ProductId, req.WareHouseId), ct);

        if (wareHouseProduct is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        wareHouseProduct.Quantity = req.Quantity;
        await warehouseProductsRepository.SaveChangesAsync(ct);

        await Send.NoContentAsync(ct);
    }
}