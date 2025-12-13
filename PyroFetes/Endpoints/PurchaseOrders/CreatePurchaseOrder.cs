using FastEndpoints;
using PyroFetes.DTO.PurchaseOrder.Request;
using PyroFetes.DTO.PurchaseOrder.Response;
using PyroFetes.DTO.PurchaseProduct.Request;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Products;
using PyroFetes.Specifications.PurchaseOrders;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class CreatePurchaseOrder(
    PurchaseOrdersRepository purchaseOrdersRepository,
    ProductsRepository productsRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreatePurchaseOrderDto, GetPurchaseOrderDto>
{
    public override void Configure()
    {
        Post("/purchaseOrders");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePurchaseOrderDto req, CancellationToken ct)
    {
        var purchaseOrder = new PurchaseOrder
        {
            PurchaseConditions = req.PurchaseConditions ?? "Conditions non précisées",
            PurchaseProducts = new List<PurchaseProduct>()
        };

        foreach (var line in req.Products)
        {
            var product = await productsRepository.GetByIdAsync(line.ProductId, ct);
            if (product == null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }

            purchaseOrder.PurchaseProducts.Add(new PurchaseProduct
            {
                ProductId = product.Id,
                Quantity = line.Quantity,
            });
        }

        await purchaseOrdersRepository.AddAsync(purchaseOrder, ct);

        await Send.OkAsync(mapper.Map<GetPurchaseOrderDto>(purchaseOrder), ct);
    }
}