using PyroFetes.DTO.Supplier.Request;
using PyroFetes.DTO.Supplier.Response;
using FastEndpoints;

namespace PyroFetes.Endpoints.Supplier;

public class CreateSupplierEndpoint(PyroFetesDbContext database) : Endpoint<CreateSupplierDto, GetSupplierDto>
{
    public override void Configure()
    {
        Post("/api/suppliers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateSupplierDto req, CancellationToken ct)
    {
        var supplier = new Models.Supplier()
        {
            Name = req.Name,
            Email = req.Email,
            Phone = req.Phone,
            Address = req.Address,
            City = req.City,
            ZipCode = req.ZipCode,
            DeliveryDelay = req.DeliveryDelay
        };
        
        database.Suppliers.Add(supplier);
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