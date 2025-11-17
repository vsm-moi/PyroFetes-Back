using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.PurchaseOrder.Request;
using PyroFetes.DTO.PurchaseOrder.Response;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class PatchPurchaseOrderPurchaseConditionsEndpoint(PyroFetesDbContext database) : Endpoint<PatchPurchaseOrderPurchaseConditionsDto, GetPurchaseOrderDto>
{
    public override void Configure()
    {
        Patch("/api/purchaseOrders/{@Id}/PurchaseConditions", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchPurchaseOrderPurchaseConditionsDto req, CancellationToken ct)
    {
        PurchaseOrder? purchaseOrder = await database.PurchaseOrders.SingleOrDefaultAsync(po => po.Id == req.Id, ct);
        if (purchaseOrder == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        purchaseOrder.PurchaseConditions = req.PurchaseConditions;
        await database.SaveChangesAsync(ct);

        GetPurchaseOrderDto responseDto = new()
        {
            Id = purchaseOrder.Id,
            PurchaseConditions = purchaseOrder.PurchaseConditions,
            GetPurchaseProductDto = purchaseOrder.PurchaseProducts
                .Select(p => new GetPurchaseProductDto
                {
                    ProductId = p.ProductId,
                    ProductReferences = p.Product.Reference,
                    ProductName = p.Product.Name,
                    ProductDuration = p.Product.Duration,
                    ProductCaliber = p.Product.Caliber,
                    ProductApprovalNumber = p.Product.ApprovalNumber,
                    ProductWeight = p.Product.Weight,
                    ProductNec = p.Product.Nec,
                    ProductImage = p.Product.Image,
                    ProductLink = p.Product.Link,
                    ProductMinimalQuantity = p.Product.MinimalQuantity,
                    PurchaseOrderId = p.PurchaseOrderId,
                    Quantity = p.Quantity,
                }).ToList()
        };
        await Send.OkAsync(responseDto, ct);
    }
}