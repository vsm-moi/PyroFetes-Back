using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Product.Request;
using PyroFetes.DTO.Product.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Products;

namespace PyroFetes.Endpoints.Products;

public class UpdateProductEndpoint(
    ProductsRepository productsRepository,
    AutoMapper.IMapper mapper) : Endpoint<UpdateProductDto, GetProductDto>
{
    public override void Configure()
    {
        Put("/products/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateProductDto req, CancellationToken ct)
    {
        Product? product = await productsRepository.FirstOrDefaultAsync(new GetProductByIdSpec(req.Id), ct);
        
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
        
        await productsRepository.UpdateAsync(product, ct);
        
        await Send.OkAsync(mapper.Map<GetProductDto>(product), ct);
    }
}