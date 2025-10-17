using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Endpoints.QuoationProduct;

public class DeleteQuotationProductRequest
{
    public int ProductId { get; set; }
    public int QuotationId { get; set; }
}

public class DeleteQuotationProductEndpoint(PyroFetesDbContext database) : Endpoint<DeleteQuotationProductRequest>
{
    public override void Configure()
    {
        Delete("/api/quotationProduct/{ProductId}/{QuotationId}", x => new {x.ProductId, x.QuotationId});
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteQuotationProductRequest req, CancellationToken ct)
    {
        var quotationProduct = await database.QuotationProducts
            .SingleOrDefaultAsync(qo => qo.ProductId == req.ProductId && qo.QuotationId == req.QuotationId, ct);

        if (quotationProduct == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        database.QuotationProducts.Remove(quotationProduct); 
        await database.SaveChangesAsync(ct);
        
        await Send.NoContentAsync(ct);
    }
}