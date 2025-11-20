using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Supplier.Request;
using PyroFetes.DTO.Supplier.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Suppliers;

namespace PyroFetes.Endpoints.Suppliers;

public class PatchSupplierDeleveryDelayEndpoint(
    SuppliersRepository suppliersRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchSupplierDeliveryDelayDto, GetSupplierDto>
{
    public override void Configure()
    {
        Patch("/api/supplier/{@Id}/DeleveryDalay", x => new {x.Id});
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(PatchSupplierDeliveryDelayDto req, CancellationToken ct)
    {
        Supplier? supplier = await suppliersRepository.FirstOrDefaultAsync(new GetSupplierByIdSpec(req.Id), ct);

        if (supplier == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        supplier.DeliveryDelay = req.DeliveryDelay;
        await suppliersRepository.UpdateAsync(supplier, ct);
        
        await Send.OkAsync(mapper.Map<GetSupplierDto>(supplier), ct);
    }
}