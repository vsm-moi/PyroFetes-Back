using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.PurchaseProduct.Request;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.PurchaseProducts;

public class CreatePurchaseProductEndpoint(PyroFetesDbContext database) : Endpoint<CreatePurchaseProductDto, GetPurchaseProductDto>
{
    public override void Configure()
    {
        Post("/api/purchaseProducts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePurchaseProductDto req, CancellationToken ct)
    {
        Product? product = await database.Products.FirstOrDefaultAsync(p => p.Id == req.ProductId, ct);
        if (product == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        PurchaseOrder? purchaseOrder = await database.PurchaseOrders.FirstOrDefaultAsync(po => po.Id == req.PurchaseOrderId, ct);
        
        if (purchaseOrder == null)
        {
            purchaseOrder = new PurchaseOrder()
            {
                PurchaseConditions = req.PurchaseOrderPurchaseConditions ?? "Conditions non précisées"
            };
            database.PurchaseOrders.Add(purchaseOrder);
            await database.SaveChangesAsync(ct);
        }
        
        PurchaseProduct purchaseProduct = new PurchaseProduct()
        {
            ProductId = product.Id,
            PurchaseOrderId = purchaseOrder.Id,
            Quantity = req.Quantity
        };
        database.PurchaseProducts.Add(purchaseProduct);
        await database.SaveChangesAsync(ct);
        
        GetPurchaseProductDto responseDto = new GetPurchaseProductDto()
        {
            ProductId = product.Id,
            ProductReferences = product.Reference,
            ProductName = product.Name,
            ProductDuration = product.Duration,
            ProductCaliber = product.Caliber,
            ProductApprovalNumber = product.ApprovalNumber,
            ProductWeight = product.Weight,
            ProductNec = product.Nec,
            ProductImage = product.Image,
            ProductLink = product.Link,
            ProductMinimalQuantity = product.MinimalQuantity,

            PurchaseOrderId = purchaseOrder.Id,
            PurchaseOrderPurchaseConditions = purchaseOrder.PurchaseConditions,
            Quantity = purchaseProduct.Quantity
        };

        await Send.OkAsync(responseDto, ct);
    }
}
