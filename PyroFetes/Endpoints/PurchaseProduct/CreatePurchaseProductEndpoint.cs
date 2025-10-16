using Microsoft.EntityFrameworkCore;
using FastEndpoints;
using PyroFetes.DTO.PurchaseProduct.Request;
using PyroFetes.DTO.PurchaseProduct.Response;

namespace PyroFetes.Endpoints.PurchaseProduct;

public class CreatePurchaseProductEndpoint(PyroFetesDbContext database) : Endpoint<CreatePurchaseProductDto, GetPurchaseProductDto>
{
    public override void Configure()
    {
        Post("/api/purchaseProducts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePurchaseProductDto req, CancellationToken ct)
    {
        var purchaseOrderExists = await database.PurchaseOrders.FirstOrDefaultAsync(a => a.Id == req.PurchaseOrderId, ct);
        
        if (purchaseOrderExists == null)
        {
            await Send.NoContentAsync(ct);
            return;
        }
        
        var purchaseProduct = new Models.PurchaseProduct()
        {
            ProductId = req.ProductId,
            PurchaseOrderId = req.PurchaseOrderId,
            Quantity = req.Quantity
        };
        database.PurchaseProducts.Add(purchaseProduct);
        
        var purchaseOrder = new Models.PurchaseOrder()
        {
            PurchaseConditions = req.PurchaseOrderPurchaseConditions,
        };
        database.PurchaseOrders.Add(purchaseOrder);
        
        await database.SaveChangesAsync(ct);
        
        GetPurchaseProductDto responseDto = new()
        {
            ProductId = purchaseProduct.ProductId,
            PurchaseOrderId = purchaseProduct.PurchaseOrderId,
            Quantity = purchaseProduct.Quantity,
            PurchaseOrderPurchaseConditions = purchaseOrder.PurchaseConditions,
        };
        
        await Send.OkAsync(responseDto, ct);
    }
}