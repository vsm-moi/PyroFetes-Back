using FastEndpoints;
using PyroFetes.DTO.Price.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Prices;
using PyroFetes.Specifications.Products;
using PyroFetes.Specifications.Suppliers;

namespace PyroFetes.Endpoints.Suppliers;

public class AddProductToSupplierEndpoint(
    SuppliersRepository suppliersRepository,
    ProductsRepository productsRepository,
    PricesRepository pricesRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreatePriceDto>
{
    public override void Configure()
    {
        Post("/suppliers/{@SupplierId}/{@ProductId}/", x => new { x.SupplierId, x.ProductId });
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(CreatePriceDto req, CancellationToken ct)
    {
        Supplier? supplier = await suppliersRepository.FirstOrDefaultAsync(new GetSupplierByIdSpec(req.SupplierId), ct);
        Product? product = await productsRepository.SingleOrDefaultAsync(new GetProductByIdSpec(req.ProductId), ct);
        if (supplier is null || product is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        Price? existingPrice = await pricesRepository.SingleOrDefaultAsync(new GetPriceByProductIdAndSupplierIdSpec(req.ProductId, req.SupplierId), ct);
        if (existingPrice is not null)
        {
            await Send.StringAsync("Le fournisseur a déjà un prix pour ce produit.", 400, cancellation: ct);
            return;
        }

        await pricesRepository.AddAsync(mapper.Map<Price>(req), ct);
        await Send.NoContentAsync(ct);
    }
}