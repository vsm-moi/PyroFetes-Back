using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Quotations;

public class DeleteQuotationRequest
{
    public int Id { get; set; }
}

public class DeleteQuotationEndpoint(PyroFetesDbContext database) : Endpoint<DeleteQuotationRequest>
{
    public override void Configure()
    {
        Delete("/api/quotations/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteQuotationRequest req, CancellationToken ct)
    {
        Quotation? quotation = await database.Quotations
            .Include(q => q.QuotationProducts)
            .SingleOrDefaultAsync(q => q.Id == req.Id, ct);

        if (quotation == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        if (quotation.QuotationProducts != null && quotation.QuotationProducts.Any())
        {
            database.QuotationProducts.RemoveRange(quotation.QuotationProducts);
        }
        
        database.Quotations.Remove(quotation); 
        await database.SaveChangesAsync(ct);
        
        await Send.NoContentAsync(ct);
    }
}