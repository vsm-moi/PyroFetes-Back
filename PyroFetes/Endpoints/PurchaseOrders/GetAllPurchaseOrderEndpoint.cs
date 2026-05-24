using FastEndpoints;
using PyroFetes.DTO.PurchaseOrder.Response;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class GetAllPurchaseOrderEndpoint(PurchaseOrdersRepository purchaseOrdersRepository) : EndpointWithoutRequest<List<GetPurchaseOrderDto>>
{
    public override void Configure()
    {
        Get("/purchaseOrders");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(await purchaseOrdersRepository.ProjectToListAsync<GetPurchaseOrderDto>(ct), ct);
    }
}