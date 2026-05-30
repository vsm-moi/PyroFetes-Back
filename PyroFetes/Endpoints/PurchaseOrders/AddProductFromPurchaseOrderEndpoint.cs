using FastEndpoints;
using PyroFetes.DTO.PurchaseProduct.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.PurchaseProducts;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class AddProductFromPurchaseOrderEndpoint(PurchaseProductsRepository purchaseProductsRepository, AutoMapper.IMapper mapper) : Endpoint<CreatePurchaseProductDto>
{
    public override void Configure()
    {
        Post("/purchaseOrders/{@PurchaseOrderId}/{@ProductId}", x => new { x.PurchaseOrderId, x.ProductId });
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(CreatePurchaseProductDto req, CancellationToken ct)
    {
        PurchaseProduct? purchaseOrderProduct =
            await purchaseProductsRepository.SingleOrDefaultAsync(new GetPurchaseProductByProductIdAndPurchaseOrderIdSpec(req.ProductId, req.PurchaseOrderId), ct);
        if (purchaseOrderProduct is not null)
        {
            await Send.StringAsync("Le produit est déjà dans le bon de commande", 400, cancellation: ct);
            return;
        }

        purchaseOrderProduct = mapper.Map<PurchaseProduct>(req);

        await purchaseProductsRepository.AddAsync(purchaseOrderProduct, ct);
        await Send.NoContentAsync(ct);
    }
}