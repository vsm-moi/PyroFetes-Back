using FastEndpoints;
using PyroFetes.DTO.Product.Response;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Products;

public class GetAllProductsEndpoint(ProductsRepository productsRepository) : EndpointWithoutRequest<List<GetProductDto>>
{
    public override void Configure()
    {
        Get("/products");
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(await productsRepository.ProjectToListAsync<GetProductDto>(ct), ct);
    }
}