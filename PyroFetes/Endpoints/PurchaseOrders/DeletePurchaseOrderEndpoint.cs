using FastEndpoints;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.PurchaseOrders;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class DeletePurchaseOrderRequest
{
    public int Id { get; set; }
}

public class DeletePurchaseOrderEndpoint(PurchaseOrdersRepository purchaseOrdersRepository) : Endpoint<DeletePurchaseOrderRequest>
{
    public override void Configure()
    {
        Delete("/purchaseOrders/{@Id}", x => new { x.Id });
        Roles("Admin");

    }

    public override async Task HandleAsync(DeletePurchaseOrderRequest req, CancellationToken ct)
    {
        PurchaseOrder? purchaseOrder = await purchaseOrdersRepository.FirstOrDefaultAsync(new GetPurchaseOrderByIdSpec(req.Id), ct);

        if (purchaseOrder is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await purchaseOrdersRepository.DeleteAsync(purchaseOrder, ct);
        await Send.NoContentAsync(ct);
    }
}