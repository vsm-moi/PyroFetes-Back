using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.DTO.Supplier.Response;

namespace PyroFetes.Endpoints.Supplier;

public class GetAllSuppliersEndpoint(PyroFetesDbContext database) : EndpointWithoutRequest<List<GetSupplierDto>>
{
    public override void Configure()
    {
        Get("/api/suppliers");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var supplier = await database.Suppliers
            .Select(supplier => new GetSupplierDto()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Email = supplier.Email,
                Phone = supplier.Phone,
                Address = supplier.Address,
                City = supplier.City,
                ZipCode = supplier.ZipCode,
                DeliveryDelay = supplier.DeliveryDelay
            }).ToListAsync(ct);
        
        await Send.OkAsync(supplier, ct);
    }
}