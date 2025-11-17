using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Product.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Products;

public class GetProductRequest
{
    public int Id { get; set; }
}

public class GetProductEndpoint(PyroFetesDbContext database) : Endpoint<GetProductRequest, GetProductDto>
{
    public override void Configure()
    {
        Get("/api/products/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetProductRequest req, CancellationToken ct)
    {
        Product? product = await database.Products
            .SingleOrDefaultAsync(x => x.Id == req.Id, ct);

        if (product == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        GetProductDto responseDto = new()
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
        };
        
        await Send.OkAsync(responseDto, ct);
    }
}