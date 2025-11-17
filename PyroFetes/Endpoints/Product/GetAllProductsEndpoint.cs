using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Product.Response;
using PyroFetes.DTO.PurchaseProduct.Response;

namespace PyroFetes.Endpoints.Product;

public class GetAllProductsEndpoint(PyroFetesDbContext database) : EndpointWithoutRequest<List<GetProductDto>>
{
    public override void Configure()
    {
        Get("/api/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var product = await database.Products
            .Select(product => new GetProductDto()
            {
                Id = product.Id,
                References = product.Reference,
                Name = product.Name,
                Duration = product.Duration,
                Caliber = product.Caliber,
                ApprovalNumber = product.ApprovalNumber,
                Weight = product.Weight,
                Nec = product.Nec,
                Image = product.Image,
                Link = product.Link,
                MinimalQuantity = product.MinimalQuantity,
            })
            .ToListAsync(ct);
        
        await Send.OkAsync(product, ct);
    }
}