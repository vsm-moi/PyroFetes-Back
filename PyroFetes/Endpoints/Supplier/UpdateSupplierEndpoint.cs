using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Supplier.Request;
using PyroFetes.DTO.Supplier.Response;

namespace PyroFetes.Endpoints.Supplier;

public class UpdateSupplierEndpoint(PyroFetesDbContext database) : Endpoint<UpdateSupplierDto, GetSupplierDto>
{
    public override void Configure()
    {
        Put("/api/suppliers/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateSupplierDto req, CancellationToken ct)
    {
        var supplier = await database.Suppliers.SingleOrDefaultAsync(x => x.Id == req.Id, ct);
        
        if (supplier == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        supplier.Name = req.Name;
        supplier.Email = req.Email;
        supplier.Phone = req.Phone;
        supplier.Address = req.Address;
        supplier.City = req.City;
        supplier.ZipCode = req.ZipCode;
        supplier.DeliveryDelay = req.DeliveryDelay;
        await database.SaveChangesAsync(ct);
        
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