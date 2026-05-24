using FastEndpoints;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.PurchaseProducts;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class DeletePurchaseProductRequest
{
    public int ProductId { get; set; }
    public int PurchaseOrderId { get; set; }
}

public class DeleteProductFromPurchaseOrderEndpoint(PurchaseProductsRepository purchaseProductsRepository) : Endpoint<DeletePurchaseProductRequest>
{
    public override void Configure()
    {
        Delete("/purchaseOrders/{@ProductId}/{@PurchaseOrderId}", x => new { x.ProductId, x.PurchaseOrderId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeletePurchaseProductRequest req, CancellationToken ct)
    {
        PurchaseProduct? purchaseProduct =
            await purchaseProductsRepository.SingleOrDefaultAsync(new GetPurchaseProductByProductIdAndPurchaseOrderIdSpec(req.ProductId, req.PurchaseOrderId), ct);

        if (purchaseProduct is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await purchaseProductsRepository.DeleteAsync(purchaseProduct, ct);
        await Send.NoContentAsync(ct);
    }
}