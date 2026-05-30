using FastEndpoints;
using PyroFetes.DTO.Supplier.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Suppliers;

namespace PyroFetes.Endpoints.Suppliers;

public class UpdateSupplierEndpoint(SuppliersRepository suppliersRepository, AutoMapper.IMapper mapper) : Endpoint<UpdateSupplierDto>
{
    public override void Configure()
    {
        Put("/suppliers/{@Id}", x => new { x.Id });
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(UpdateSupplierDto req, CancellationToken ct)
    {
        Supplier? supplier = await suppliersRepository.FirstOrDefaultAsync(new GetSupplierByIdSpec(req.Id), ct);
        if (supplier is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        mapper.Map(req, supplier);

        await suppliersRepository.SaveChangesAsync(ct);
        await Send.NoContentAsync(ct);
    }
}