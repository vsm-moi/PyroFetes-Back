using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Product.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Products;

namespace PyroFetes.Endpoints.Products;

public class GetProductRequest
{
    public int Id { get; set; }
}

public class GetProductEndpoint(
    ProductsRepository productsRepository,
    AutoMapper.IMapper mapper) : Endpoint<GetProductRequest, GetProductDto>
{
    public override void Configure()
    {
        Get("/products/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetProductRequest req, CancellationToken ct)
    {
        Product? product = await productsRepository.FirstOrDefaultAsync(new GetProductByIdSpec(req.Id), ct);

        if (product == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        await  Send.OkAsync(mapper.Map<GetProductDto>(product), ct);
    }
}