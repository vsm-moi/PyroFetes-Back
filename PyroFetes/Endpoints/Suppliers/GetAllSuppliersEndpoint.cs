using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Supplier.Response;

namespace PyroFetes.Endpoints.Suppliers;

public class GetAllSuppliersEndpoint(PyroFetesDbContext database) : EndpointWithoutRequest<List<GetSupplierDto>>
{
    public override void Configure()
    {
        Get("/api/suppliers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        List<GetSupplierDto> supplier = await database.Suppliers
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