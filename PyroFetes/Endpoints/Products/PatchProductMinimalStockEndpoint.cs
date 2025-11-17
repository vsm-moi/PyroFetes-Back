using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Product.Request;
using PyroFetes.DTO.Product.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Products;

public class PatchProductMinimalStockEndpoint(PyroFetesDbContext database)
    : Endpoint<PatchProductMinimalStockDto, GetProductDto>
{
    public override void Configure()
    {
        Patch("/api/products/{@Id}/MinimalStock", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchProductMinimalStockDto req, CancellationToken ct)
    {
        Product? product = await database.Products.SingleOrDefaultAsync(po => po.Id == req.Id, ct);
        if (product == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

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