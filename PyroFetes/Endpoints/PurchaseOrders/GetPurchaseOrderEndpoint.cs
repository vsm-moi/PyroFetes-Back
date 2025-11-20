using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.PurchaseOrder.Response;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.PurchaseOrders;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class GetPurchaseOrderRequest
{
    public int Id { get; set; }
}

public class GetPurchaseOrderEndpoint(
    PurchaseOrdersRepository purchaseOrdersRepository,
    AutoMapper.IMapper mapper) : Endpoint<GetPurchaseOrderRequest, GetPurchaseOrderDto>
{
    public override void Configure()
    {
        Get("/purchaseOrders/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetPurchaseOrderRequest req, CancellationToken ct)
    {
        PurchaseOrder? purchaseOrder = await purchaseOrdersRepository.FirstOrDefaultAsync(new GetPurchaseOrderByIdSpec(req.Id), ct);

        if (purchaseOrder == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        await Send.OkAsync(mapper.Map<GetPurchaseOrderDto>(purchaseOrder), ct);
    }
}