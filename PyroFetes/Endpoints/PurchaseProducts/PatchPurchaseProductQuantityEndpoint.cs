using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.PurchaseProduct.Request;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.PurchaseProducts;

namespace PyroFetes.Endpoints.PurchaseProducts;

public class PatchPurchaseProductQuantityEndpoint(
    PurchaseProductsRepository purchaseProductsRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchPurchaseProductQuantityDto, GetPurchaseProductDto>
{
    public override void Configure()
    {
        Patch("/purchaseProducts/{@ProductId}/{@PurchaseOrderId}/Quantity", x => new { x.ProductId, x.PurchaseOrderId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchPurchaseProductQuantityDto req, CancellationToken ct)
    {
        PurchaseProduct? purchaseProduct =
            await purchaseProductsRepository.FirstOrDefaultAsync(
                new GetPurchaseProductByProductIdAndPurchaseOrderIdSpec(req.ProductId, req.PurchaseOrderId), ct);
        
        if (purchaseProduct == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        purchaseProduct.Quantity = req.Quantity;
        await purchaseProductsRepository.UpdateAsync(purchaseProduct, ct);

        await Send.OkAsync(mapper.Map<GetPurchaseProductDto>(purchaseProduct), ct);
    }
}