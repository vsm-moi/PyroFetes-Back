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
        
        var product = await database.Products.SingleOrDefaultAsync(p => p.Reference == req.ProductReferences, ct);
        if (product != null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        var productAdded = new Models.Product()
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
        database.Products.Add(productAdded);
        await database.SaveChangesAsync(ct);
        
        var price = await database.Prices.SingleOrDefaultAsync(p => p.ProductId == req.ProductId && p.SupplierId == req.SupplierId, ct);
        if (price != null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        var priceAdded = new Models.Price()
        {
            SellingPrice = req.SellingPrice,
            SupplierId = supplier.Id,
            ProductId = productAdded.Id,
        };
        database.Prices.Add(priceAdded);
        await database.SaveChangesAsync(ct);
        
        var responseDto = new GetPriceDto()
        {
            SellingPrice = priceAdded.SellingPrice,
            SupplierId = supplier.Id,
            ProductId = productAdded.Id,
            SupplierName = supplier.Name,
            SupplierEmail = supplier.Email,
            SupplierPhone = supplier.Phone,
            SupplierAddress = supplier.Address,
            SupplierCity = supplier.City,
            SupplierZipCode = supplier.ZipCode,
            SupplierDeliveryDelay = supplier.DeliveryDelay,
            ProductReferences = productAdded.Reference,
            ProductName = productAdded.Name,
            ProductDuration = productAdded.Duration,
            ProductCaliber = productAdded.Caliber,
            ProductApprovalNumber = productAdded.ApprovalNumber,
            ProductWeight = productAdded.Weight,
            ProductNec = productAdded.Nec,
            ProductImage = productAdded.Image,
            ProductLink = productAdded.Link,
            ProductMinimalQuantity = productAdded.MinimalQuantity
        };

        await Send.OkAsync(responseDto, ct);
    }
}
