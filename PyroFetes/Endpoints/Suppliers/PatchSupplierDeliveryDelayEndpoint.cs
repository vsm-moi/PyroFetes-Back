using FastEndpoints;
using PyroFetes.DTO.Supplier.Request;
using PyroFetes.DTO.Supplier.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Suppliers;

namespace PyroFetes.Endpoints.Suppliers;

public class PatchSupplierDeliveryDelayEndpoint(SuppliersRepository suppliersRepository, AutoMapper.IMapper mapper) : Endpoint<PatchSupplierDeliveryDelayDto>
{
    public override void Configure()
    {
        Patch("/suppliers/{@Id}/deliveryDelay", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchSupplierDeliveryDelayDto req, CancellationToken ct)
    {
        Supplier? supplier = await suppliersRepository.SingleOrDefaultAsync(new GetSupplierByIdSpec(req.Id), ct);

        if (supplier is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        supplier.DeliveryDelay = req.DeliveryDelay;
        await suppliersRepository.SaveChangesAsync(ct);

        await Send.OkAsync(mapper.Map<GetSupplierDto>(supplier), ct);
    }
}