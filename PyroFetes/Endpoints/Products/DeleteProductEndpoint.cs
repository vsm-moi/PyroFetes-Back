using FastEndpoints;
using PyroFetes.Endpoints.Deliverers;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Deliverers;
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
        Delete("/products/{@id}", x=>new {x.ProductId});
        AllowAnonymous();

    }

    public override async Task HandleAsync(DeleteProductsRequest req, CancellationToken ct)
    {
        Product? product = await productsRepository.FirstOrDefaultAsync(new GetProductByIdSpec(req.ProductId), ct);

        if (product == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        await productsRepository.DeleteAsync(product, ct);

        await Send.OkAsync(ct);
    }

}