using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.PurchaseProduct.Request;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.PurchaseProducts;

public class PatchPurchaseProductQuantityEndpoint(PyroFetesDbContext database) : Endpoint<PatchPurchaseProductQuantityDto, GetPurchaseProductDto>
{
    public override void Configure()
    {
        Patch("/api/purchaseProducts/{@ProductId}/{@PurchaseOrderId}/Quantity", x => new { x.ProductId, x.PurchaseOrderId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchPurchaseProductQuantityDto req, CancellationToken ct)
    {
        PurchaseProduct? purchaseProduct = await database.PurchaseProducts.SingleOrDefaultAsync(po => po.ProductId == req.ProductId && po.PurchaseOrderId == req.PurchaseOrderId, ct);
        if (purchaseProduct == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        purchaseProduct.Quantity = req.Quantity;
        await database.SaveChangesAsync(ct);

        GetPurchaseProductDto responseDto = new()
        {
            ProductId = purchaseProduct.ProductId,
            PurchaseOrderId = purchaseProduct.PurchaseOrderId,
            Quantity = purchaseProduct.Quantity
        };
        await Send.OkAsync(responseDto, ct);
    }
}