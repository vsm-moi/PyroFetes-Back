using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Product.Request;
using PyroFetes.DTO.Product.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Products;

namespace PyroFetes.Endpoints.Products;

public class PatchProductMinimalStockEndpoint(
    ProductsRepository productsRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchProductMinimalStockDto, GetProductDto>
{
    public override void Configure()
    {
        Patch("/api/products/{@Id}/MinimalStock", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchProductMinimalStockDto req, CancellationToken ct)
    {
        Product? product = await productsRepository.FirstOrDefaultAsync(new GetProductByIdSpec(req.Id), ct);
        
        if (product == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        product.MinimalQuantity = req.MinimalQuantity;
        await productsRepository.UpdateAsync(product, ct);
        
        await Send.OkAsync(mapper.Map<GetProductDto>(product), ct);
    }
}