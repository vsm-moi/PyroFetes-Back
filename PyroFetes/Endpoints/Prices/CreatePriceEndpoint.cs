using FastEndpoints;
using PyroFetes.DTO.Price.Request;
using PyroFetes.DTO.Price.Response;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Prices;
using PyroFetes.Specifications.Products;
using PyroFetes.Specifications.Suppliers;

namespace PyroFetes.Endpoints.Prices;

public class CreatePriceEndpoint(
    SuppliersRepository suppliersRepository,
    ProductsRepository productsRepository,
    PricesRepository pricesRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreatePriceDto, GetPriceDto>
{
    public override void Configure()
    {
        Post("/api/prices");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePriceDto req, CancellationToken ct)
    {
        // Gestion du fournisseur
        var supplier = await suppliersRepository.FirstOrDefaultAsync(new GetSupplierByIdSpec(req.SupplierId), ct);
        if (supplier == null)
        {
            supplier = new Models.Supplier()
            {
                Name = req.SupplierName,
                Email = req.SupplierEmail,
                Phone = req.SupplierPhone,
                Address = req.SupplierAddress,
                City = req.SupplierCity,
                ZipCode = req.SupplierZipCode,
                DeliveryDelay = req.SupplierDeliveryDelay
            };
            await  suppliersRepository.AddAsync(supplier, ct);
        }

        // Gestion du produit
        var product = await productsRepository.FirstOrDefaultAsync(new GetProductByIdSpec(req.ProductId), ct);
        if (product == null)
        {
            product = new Models.Product()
            {
                Reference = req.ProductReferences,
                Name = req.ProductName,
                Duration = req.ProductDuration,
                Caliber = req.ProductCaliber,
                ApprovalNumber = req.ProductApprovalNumber,
                Weight = req.ProductWeight,
                Nec = req.ProductNec,
                Image = req.ProductImage,
                Link = req.ProductLink,
                MinimalQuantity = req.ProductMinimalQuantity
            };
            await productsRepository.AddAsync(product, ct);
        }

        // Vérifie si le prix existe déjà pour ce fournisseur et produit
        var existingPrice = await pricesRepository.FirstOrDefaultAsync(new GetPriceByProductIdAndSupplierIdSpec(req.ProductId, req.SupplierId), ct);

        if (existingPrice != null)
        {
            await Send.StringAsync("Le fournisseur a déjà un prix pour ce produit.", 400, cancellation: ct);
            return;
        }

        // Création du prix
        var priceAdded = new Models.Price()
        {
            SellingPrice = req.SellingPrice,
            SupplierId = supplier.Id,
            ProductId = product.Id
        };
        await pricesRepository.AddAsync(priceAdded, ct);

      
        await Send.OkAsync(mapper.Map<GetPriceDto>(priceAdded), ct);
    }
}
