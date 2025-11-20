using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Supplier.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Suppliers;

namespace PyroFetes.Endpoints.Suppliers;

public class GetSupplierRequest
{
    public int Id { get; set; }
}

public class GetSupplierEndpoint(
    SuppliersRepository suppliersRepository,
    AutoMapper.IMapper mapper) : Endpoint<GetSupplierRequest, GetSupplierDto>
{
    public override void Configure()
    {
        Get("/api/suppliers/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GetSupplierRequest req, CancellationToken ct)
    {
        Supplier? supplier = await suppliersRepository.FirstOrDefaultAsync(new GetSupplierByIdSpec(req.Id), ct);

        if (supplier == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await Send.OkAsync(mapper.Map<GetSupplierDto>(supplier), ct);
    }
}