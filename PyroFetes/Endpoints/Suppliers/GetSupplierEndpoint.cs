using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Supplier.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Suppliers;

public class GetSupplierRequest
{
    public int Id { get; set; }
}

public class GetSupplierEndpoint(PyroFetesDbContext database) : Endpoint<GetSupplierRequest, GetSupplierDto>
{
    public override void Configure()
    {
        Get("/api/suppliers/{@Id}", x => new {x.Id});
    }
    
    public override async Task HandleAsync(GetSupplierRequest req, CancellationToken ct)
    {
        Supplier? supplier = await database.Suppliers
            .SingleOrDefaultAsync(x => x.Id == req.Id, ct);

        if (supplier == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        GetSupplierDto responseDto = new()
        {
            Id = supplier.Id,
            Name = supplier.Name,
            Email = supplier.Email,
            Phone = supplier.Phone,
            Address = supplier.Address,
            City = supplier.City,
            ZipCode = supplier.ZipCode,
            DeliveryDelay = supplier.DeliveryDelay
        };
        await Send.OkAsync(responseDto, ct);
    }
}