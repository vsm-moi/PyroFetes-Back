using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Product.Request;
using PyroFetes.DTO.Product.Response;

namespace PyroFetes.Endpoints.Product;

public class UpdateProductEndpoint(PyroFetesDbContext database) : Endpoint<UpdateProductDto, GetProductDto>
{
    public override void Configure()
    {
        Put("/api/products/{@Id}", x => new {x.Id});
    }

    public override async Task HandleAsync(UpdateProductDto req, CancellationToken ct)
    {
        var product = await database.Products.SingleOrDefaultAsync(x => x.Id == req.Id, ct);
        
        if (product == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        product.Reference = req.References;
        product.Name = req.Name;
        product.Duration = req.Duration;
        product.Caliber = req.Caliber;
        product.ApprovalNumber = req.ApprovalNumber;
        product.Weight = req.Weight;
        product.Nec = req.Nec;
        product.Image = req.Image;
        product.Link = req.Link;
        product.MinimalQuantity = req.MinimalQuantity;
        await database.SaveChangesAsync(ct);
        
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