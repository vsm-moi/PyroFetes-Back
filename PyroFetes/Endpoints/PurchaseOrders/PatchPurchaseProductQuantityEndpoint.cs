using FastEndpoints;
using PyroFetes.DTO.PurchaseProduct.Request;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.PurchaseProducts;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class PatchPurchaseProductQuantityEndpoint(PurchaseProductsRepository purchaseProductsRepository, AutoMapper.IMapper mapper)
    : Endpoint<PatchPurchaseProductQuantityDto>
{
    public override void Configure()
    {
        Patch("/purchaseOrders/{@ProductId}/{@PurchaseOrderId}/Quantity", x => new { x.ProductId, x.PurchaseOrderId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchPurchaseProductQuantityDto req, CancellationToken ct)
    {
        PurchaseProduct? purchaseProduct =
            await purchaseProductsRepository.SingleOrDefaultAsync(new GetPurchaseProductByProductIdAndPurchaseOrderIdSpec(req.ProductId, req.PurchaseOrderId), ct);

        if (purchaseProduct is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        mapper.Map(req, purchaseProduct);

        await purchaseProductsRepository.SaveChangesAsync(ct);
        await Send.NoContentAsync(ct);
    }
}