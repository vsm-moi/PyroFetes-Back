using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.PurchaseOrders;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class DeletePurchaseOrderRequest
{
    public int Id { get; set; }
}

public class DeletePurchaseOrderEndpoint(
    PurchaseOrdersRepository purchaseOrdersRepository,
    PurchaseProductsRepository purchaseProductsRepository) : Endpoint<DeletePurchaseOrderRequest>
{
    public override void Configure()
    {
        Delete("/purchaseOrders/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeletePurchaseOrderRequest req, CancellationToken ct)
    {
        PurchaseOrder? purchaseOrder = await purchaseOrdersRepository.FirstOrDefaultAsync(new GetPurchaseOrderByIdSpec(req.Id), ct);

        if (purchaseOrder == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        if (purchaseOrder.PurchaseProducts != null && purchaseOrder.PurchaseProducts.Any())
        {
            await purchaseProductsRepository.DeleteRangeAsync(purchaseOrder.PurchaseProducts, ct);
        }
        
        await purchaseOrdersRepository.DeleteAsync(purchaseOrder, ct);   
        
        await Send.NoContentAsync(ct);
    }
}