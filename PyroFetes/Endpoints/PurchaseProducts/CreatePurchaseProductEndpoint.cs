using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.PurchaseProduct.Request;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Products;
using PyroFetes.Specifications.PurchaseOrders;

namespace PyroFetes.Endpoints.PurchaseProducts;

public class CreatePurchaseProductEndpoint(
    ProductsRepository productsRepository,
    PurchaseOrdersRepository purchaseOrdersRepository,
    PurchaseProductsRepository purchaseProductsRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreatePurchaseProductDto, GetPurchaseProductDto>
{
    public override void Configure()
    {
        Post("/api/purchaseProducts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePurchaseProductDto req, CancellationToken ct)
    {
        Product? product = await productsRepository.FirstOrDefaultAsync(new GetProductByIdSpec(req.ProductId), ct);
        if (product == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        PurchaseOrder? purchaseOrder = await purchaseOrdersRepository.FirstOrDefaultAsync(new GetPurchaseOrderByIdSpec(req.PurchaseOrderId), ct);
        
        if (purchaseOrder == null)
        {
            purchaseOrder = new PurchaseOrder()
            {
                PurchaseConditions = req.PurchaseOrderPurchaseConditions ?? "Conditions non précisées"
            };
            await purchaseOrdersRepository.AddAsync(purchaseOrder, ct);
        }
        
        PurchaseProduct purchaseProduct = new PurchaseProduct()
        {
            ProductId = product.Id,
            PurchaseOrderId = purchaseOrder.Id,
            Quantity = req.Quantity
        };
        
        await purchaseProductsRepository.AddAsync(purchaseProduct, ct);
        
        await Send.OkAsync(mapper.Map<GetPurchaseProductDto>(purchaseProduct), ct);
    }
}
