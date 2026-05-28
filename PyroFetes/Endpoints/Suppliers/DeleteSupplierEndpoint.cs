using FastEndpoints;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Suppliers;

namespace PyroFetes.Endpoints.Suppliers;

public class DeleteSupplierRequest
{
    public int Id { get; set; }
}

public class DeleteSupplierEndpoint(SuppliersRepository suppliersRepository) : Endpoint<DeleteSupplierRequest>
{
    public override void Configure()
    {
        Delete("/suppliers/{@Id}", x => new { x.Id });
        Roles("Admin");
    }

    public override async Task HandleAsync(DeleteSupplierRequest req, CancellationToken ct)
    {
        Supplier? supplier = await suppliersRepository.SingleOrDefaultAsync(new GetSupplierByIdSpec(req.Id), ct);

        if (supplier is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await suppliersRepository.DeleteAsync(supplier, ct);
        await Send.NoContentAsync(ct);
    }
}