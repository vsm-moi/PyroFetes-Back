using FastEndpoints;
using PyroFetes.DTO.Product.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Products;

namespace PyroFetes.Endpoints.Products;

public class PatchProductMinimalStockEndpoint(ProductsRepository productsRepository, AutoMapper.IMapper mapper) : Endpoint<PatchProductMinimalStockDto>
{
    public override void Configure()
    {
        Patch("/products/{@Id}/MinimalStock", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchProductMinimalStockDto req, CancellationToken ct)
    {
        Product? product = await productsRepository.SingleOrDefaultAsync(new GetProductByIdSpec(req.Id), ct);

        if (product is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        mapper.Map(req, product);
            
        await productsRepository.UpdateAsync(product, ct);
        await Send.NoContentAsync(ct);
    }
}