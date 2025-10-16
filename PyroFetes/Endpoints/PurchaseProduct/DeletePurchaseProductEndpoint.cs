using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Endpoints.PurchaseProduct;

public class DeletePurchaseOrderRequest
{
    public int Id { get; set; }
}

public class DeletePurchaseOrderEndpoint(PyroFetesDbContext database) : Endpoint<DeletePurchaseOrderRequest>
{
    public override void Configure()
    {
        Delete("/api/purchaseOrders/{Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeletePurchaseOrderRequest req, CancellationToken ct)
    {
        var purchaseOrder = await database.PurchaseOrders
            .Include(po => po.PurchaseProducts)
            .SingleOrDefaultAsync(po => po.Id == req.Id, ct);

        if (purchaseOrder == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        if (purchaseOrder.PurchaseProducts != null && purchaseOrder.PurchaseProducts.Any())
        {
            database.PurchaseProducts.RemoveRange(purchaseOrder.PurchaseProducts);
        }
        
        database.PurchaseOrders.Remove(purchaseOrder); 
        await database.SaveChangesAsync(ct);
        
        await Send.NoContentAsync(ct);
    }
}