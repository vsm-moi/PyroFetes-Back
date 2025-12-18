using AutoMapper;
using FastEndpoints;
using PyroFetes.DTO.Product.Response;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Products;

namespace PyroFetes.Endpoints.Products;

public class GetAllProductsUnderLimitEndpoint(ProductsRepository productsRepository) : EndpointWithoutRequest<List<GetProductDto>>
{
    public override void Configure()
    {
        Get("/products/underLimit");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {   
        await Send.OkAsync(await productsRepository.ProjectToListAsync<GetProductDto>(new GetProductsUnderLimitSpec(), ct), ct);
    }
}