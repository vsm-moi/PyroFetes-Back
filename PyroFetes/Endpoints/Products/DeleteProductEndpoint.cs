using FastEndpoints;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Products;

namespace PyroFetes.Endpoints.Products;

public class DeleteProductsRequest
{
    public int ProductId { get; set; }
}

public class DeleteProductEndpoint(ProductsRepository productsRepository) : Endpoint<DeleteProductsRequest>
{
    public override void Configure()
    {
        Delete("/products/{@Id}", x => new { x.ProductId });
        Roles("Admin");

    }

    public override async Task HandleAsync(DeleteProductsRequest req, CancellationToken ct)
    {
        Product? product = await productsRepository.SingleOrDefaultAsync(new GetProductByIdSpec(req.ProductId), ct);

        if (product is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await productsRepository.DeleteAsync(product, ct);
        await Send.OkAsync(ct);
    }
}