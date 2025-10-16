using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Endpoints.PurchaseProduct;

public class DeletePurchaseProductRequest
{
    public int ProductId { get; set; }
    public int PurchaseOrderId { get; set; }
}

public class DeletePurchaseOrderEndpoint(PyroFetesDbContext database) : Endpoint<DeletePurchaseProductRequest>
{
    public override void Configure()
    {
        Delete("/api/purchaseProducts/{ProductId}/{PurchaseOrderId}", x => new {x.ProductId, x.PurchaseOrderId});
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeletePurchaseProductRequest req, CancellationToken ct)
    {
        var purchaseProduct = await database.PurchaseProducts
            .SingleOrDefaultAsync(po => po.ProductId == req.ProductId && po.PurchaseOrderId == req.PurchaseOrderId, ct);

        if (purchaseProduct == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        database.PurchaseProducts.Remove(purchaseProduct); 
        await database.SaveChangesAsync(ct);
        
        await Send.NoContentAsync(ct);
    }
}