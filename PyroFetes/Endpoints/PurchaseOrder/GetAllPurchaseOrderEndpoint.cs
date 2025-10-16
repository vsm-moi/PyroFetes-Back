using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.PurchaseOrder.Response;
using PyroFetes.DTO.PurchaseProduct.Response;

namespace PyroFetes.Endpoints.PurchaseOrder;

public class GetAllPurchaseOrderEndpoint(PyroFetesDbContext database) : EndpointWithoutRequest<List<GetPurchaseOrderDto>>
{
    public override void Configure()
    {
        Get("/api/purchaseOrders");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var purchaseOrder = await database.PurchaseOrders
            .Include(p => p.PurchaseProducts)
            .Select(purchaseOrder => new GetPurchaseOrderDto()
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
            })
            .ToListAsync(ct);
        
        await Send.OkAsync(purchaseOrder, ct);
    }
}