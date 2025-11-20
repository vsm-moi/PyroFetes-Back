using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.PurchaseProducts;

namespace PyroFetes.Endpoints.PurchaseProducts;

public class DeletePurchaseProductRequest
{
    public int ProductId { get; set; }
    public int PurchaseOrderId { get; set; }
}

public class DeletePurchaseProductEndpoint(PurchaseProductsRepository purchaseProductsRepository) : Endpoint<DeletePurchaseProductRequest>
{
    public override void Configure()
    {
        Delete("/purchaseProducts/{@ProductId}/{@PurchaseOrderId}", x => new {x.ProductId, x.PurchaseOrderId});
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeletePurchaseProductRequest req, CancellationToken ct)
    {
        PurchaseProduct? purchaseProduct = await purchaseProductsRepository.FirstOrDefaultAsync(
            new GetPurchaseProductByProductIdAndPurchaseOrderIdSpec(req.ProductId, req.PurchaseOrderId), ct);

        if (purchaseProduct == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        await purchaseProductsRepository.DeleteAsync(purchaseProduct, ct);
        
        await Send.NoContentAsync(ct);
    }
}