using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.PurchaseOrder.Response;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class GetPurchaseOrderRequest
{
    public int Id { get; set; }
}

public class GetPurchaseOrderEndpoint(PyroFetesDbContext database) : Endpoint<GetPurchaseOrderRequest, GetPurchaseOrderDto>
{
    public override void Configure()
    {
        Get("/api/purchaseOrders/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetPurchaseOrderRequest req, CancellationToken ct)
    {
        PurchaseOrder? purchaseOrder = await database.PurchaseOrders
            .SingleOrDefaultAsync(x => x.Id == req.Id, ct);

        if (purchaseOrder == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
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