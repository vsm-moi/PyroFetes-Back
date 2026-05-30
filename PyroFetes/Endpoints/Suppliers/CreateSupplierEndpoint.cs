using FastEndpoints;
using PyroFetes.DTO.Supplier.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Suppliers;

public class CreateSupplierEndpoint(SuppliersRepository suppliersRepository, AutoMapper.IMapper mapper) : Endpoint<CreateSupplierDto>
{
    public override void Configure()
    {
        Post("/suppliers");
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(CreateSupplierDto req, CancellationToken ct)
    {
        await suppliersRepository.AddAsync(mapper.Map<Supplier>(req), ct);
        await Send.NoContentAsync(ct);
    }
}