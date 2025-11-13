using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Supplier.Request;
using PyroFetes.DTO.Supplier.Response;

namespace PyroFetes.Endpoints.Supplier;

public class PatchSupplierDeleveryDelayEndpoint(PyroFetesDbContext database) : Endpoint<PatchSupplierDeliveryDelayDto, GetSupplierDto>
{
    public override void Configure()
    {
        Get("/api/supplier/{@Id}/DeleveryDalay", x => new {x.Id});
    }
    
    public override async Task HandleAsync(PatchSupplierDeliveryDelayDto req, CancellationToken ct)
    {
        var supplier = await database.Suppliers.SingleOrDefaultAsync(x => x.Id == req.Id, ct);

        if (supplier == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        supplier.DeliveryDelay = req.DeliveryDelay;
        await database.SaveChangesAsync(ct);

        GetSupplierDto responseDto = new()
        {
            Id = supplier.Id,
            DeliveryDelay = supplier.DeliveryDelay,
        };
        
        await Send.OkAsync(responseDto, ct);
    }
}