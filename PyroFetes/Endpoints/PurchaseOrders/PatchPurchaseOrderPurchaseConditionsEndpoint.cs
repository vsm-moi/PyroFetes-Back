using FastEndpoints;
using PyroFetes.DTO.PurchaseOrder.Request;
using PyroFetes.DTO.PurchaseOrder.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.PurchaseOrders;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class PatchPurchaseOrderPurchaseConditionsEndpoint(PurchaseOrdersRepository purchaseOrdersRepository, AutoMapper.IMapper mapper)
    : Endpoint<PatchPurchaseOrderPurchaseConditionsDto>
{
    public override void Configure()
    {
        Patch("/purchaseOrders/{@Id}/PurchaseConditions", x => new { x.Id });
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(PatchPurchaseOrderPurchaseConditionsDto req, CancellationToken ct)
    {
        PurchaseOrder? purchaseOrder = await purchaseOrdersRepository.SingleOrDefaultAsync(new GetPurchaseOrderByIdSpec(req.Id), ct);
        if (purchaseOrder is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        mapper.Map(req, purchaseOrder);

        await purchaseOrdersRepository.UpdateAsync(purchaseOrder, ct);
        await Send.NoContentAsync(ct);
    }
}