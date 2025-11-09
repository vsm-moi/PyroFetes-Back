using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Price.Request;
using PyroFetes.DTO.Price.Response;

namespace PyroFetes.Endpoints.Price;

public class CreatePriceEndpoint(PyroFetesDbContext database) : Endpoint<CreatePriceDto, GetPriceDto>
{
    public override void Configure()
    {
        Post("/api/prices");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePriceDto req, CancellationToken ct)
    {
        // Gestion du fournisseur
        var supplier = await database.Suppliers.FirstOrDefaultAsync(s => s.Id == req.SupplierId, ct);
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
            database.Suppliers.Add(supplier);
            await database.SaveChangesAsync(ct);
        }

        // Gestion du produit
        var product = await database.Products.SingleOrDefaultAsync(p => p.Id == req.ProductId, ct);
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
            database.Products.Add(product);
            await database.SaveChangesAsync(ct);
        }

        // Vérifie si le prix existe déjà pour ce fournisseur et produit
        var existingPrice = await database.Prices
            .SingleOrDefaultAsync(p => p.ProductId == product.Id && p.SupplierId == supplier.Id, ct);

        if (existingPrice != null)
        {
            await Send.ConflictAsync("Le fournisseur a déjà un prix pour ce produit.", ct);
            return;
        }

        // Création du prix
        var priceAdded = new Models.Price()
        {
            SellingPrice = req.SellingPrice,
            SupplierId = supplier.Id,
            ProductId = product.Id
        };
        database.Prices.Add(priceAdded);
        await database.SaveChangesAsync(ct);

        // Création du DTO de réponse
        var responseDto = new GetPriceDto()
        {
            SellingPrice = priceAdded.SellingPrice,
            SupplierId = supplier.Id,
            ProductId = product.Id,
            SupplierName = supplier.Name,
            SupplierEmail = supplier.Email,
            SupplierPhone = supplier.Phone,
            SupplierAddress = supplier.Address,
            SupplierCity = supplier.City,
            SupplierZipCode = supplier.ZipCode,
            SupplierDeliveryDelay = supplier.DeliveryDelay,
            ProductReferences = product.Reference,
            ProductName = product.Name,
            ProductDuration = product.Duration,
            ProductCaliber = product.Caliber,
            ProductApprovalNumber = product.ApprovalNumber,
            ProductWeight = product.Weight,
            ProductNec = product.Nec,
            ProductImage = product.Image,
            ProductLink = product.Link,
            ProductMinimalQuantity = product.MinimalQuantity
        };

        await Send.OkAsync(responseDto, ct);
    }
}
