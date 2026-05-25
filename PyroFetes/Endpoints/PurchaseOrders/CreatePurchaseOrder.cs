using FastEndpoints;
using PyroFetes.DTO.PurchaseOrder.Request;
using PyroFetes.DTO.PurchaseProduct.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Products;
using PyroFetes.Specifications.PurchaseProducts;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class CreatePurchaseOrder(
    PurchaseOrdersRepository purchaseOrdersRepository,
    ProductsRepository productsRepository,
    PurchaseProductsRepository purchaseProductsRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreatePurchaseOrderDto>
{
    public override void Configure()
    {
        Post("/purchaseOrders");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePurchaseOrderDto req, CancellationToken ct)
    {
        PurchaseOrder purchaseOrder = mapper.Map<PurchaseOrder>(req);
        await purchaseOrdersRepository.AddAsync(purchaseOrder, ct);

        if (req.Products != null)
        {
            foreach (CreatePurchaseOrderProductDto line in req.Products)
            {
                Product? product = await productsRepository.SingleOrDefaultAsync(new GetProductByIdSpec(line.ProductId), ct);
                if (product is null)
                {
                    await Send.NotFoundAsync(ct);
                    return;
                }

                PurchaseProduct? purchaseProduct =
                    await purchaseProductsRepository.SingleOrDefaultAsync(new GetPurchaseProductByProductIdAndPurchaseOrderIdSpec(line.ProductId, purchaseOrder.Id), ct);

                if (purchaseProduct is not null)
                {
                    await Send.StringAsync("Le produit est déjà dans le bon de commande", 400, cancellation: ct);
                }

                PurchaseProduct? productOnPurchase = mapper.Map<PurchaseProduct>(line);
                productOnPurchase.PurchaseOrderId = purchaseOrder.Id;

                await purchaseProductsRepository.AddAsync(productOnPurchase, ct);
            }
        }
        await Send.NoContentAsync(ct);
    }
}