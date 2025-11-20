using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Supplier.Response;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Suppliers;

public class GetAllSuppliersEndpoint(SuppliersRepository suppliersRepository) : EndpointWithoutRequest<List<GetSupplierDto>>
{
    public override void Configure()
    {
        Get("/suppliers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(await suppliersRepository.ProjectToListAsync<GetSupplierDto>(ct), ct);
    }
}