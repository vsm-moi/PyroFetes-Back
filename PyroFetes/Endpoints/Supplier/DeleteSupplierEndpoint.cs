using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Endpoints.Supplier;

public class DeleteSupplierRequest
{
    public int Id { get; set; }
}

public class DeleteSupplierEndpoint(PyroFetesDbContext database) : Endpoint<DeleteSupplierRequest>
{
    public override void Configure()
    {
        Delete("/api/suppliers/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(DeleteSupplierRequest req, CancellationToken ct)
    {
        var supplier = await database.Suppliers.SingleOrDefaultAsync(x => x.Id == req.Id, ct);

        if (supplier == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        database.Suppliers.Remove(supplier);
        await database.SaveChangesAsync(ct);
        
        await Send.NoContentAsync(ct);
    }
}