using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.PurchaseOrder.Request;
using PyroFetes.DTO.PurchaseOrder.Response;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.PurchaseOrders;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class PatchPurchaseOrderPurchaseConditionsEndpoint(
    PurchaseOrdersRepository purchaseOrdersRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchPurchaseOrderPurchaseConditionsDto, GetPurchaseOrderDto>
{
    public override void Configure()
    {
        Patch("/api/purchaseOrders/{@Id}/PurchaseConditions", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchPurchaseOrderPurchaseConditionsDto req, CancellationToken ct)
    {
        PurchaseOrder? purchaseOrder = await purchaseOrdersRepository.FirstOrDefaultAsync(new GetPurchaseOrderByIdSpec(req.Id), ct);
        if (purchaseOrder == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        purchaseOrder.PurchaseConditions = req.PurchaseConditions;
        await purchaseOrdersRepository.UpdateAsync(purchaseOrder, ct);

        await Send.OkAsync(mapper.Map<GetPurchaseOrderDto>(purchaseOrder), ct);
    }
}