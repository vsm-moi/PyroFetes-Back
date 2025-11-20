using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.QuotationProducts;

namespace PyroFetes.Endpoints.QuotationProducts;

public class DeleteQuotationProductRequest
{
    public int ProductId { get; set; }
    public int QuotationId { get; set; }
}

public class DeleteQuotationProductEndpoint(QuotationProductsRepository quotationProductsRepository) : Endpoint<DeleteQuotationProductRequest>
{
    public override void Configure()
    {
        Delete("/api/quotationProduct/{@ProductId}/{@QuotationId}", x => new {x.ProductId, x.QuotationId});
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteQuotationProductRequest req, CancellationToken ct)
    {
        QuotationProduct? quotationProduct =
            await quotationProductsRepository.FirstOrDefaultAsync(
                new GetQuotationProductByProductIdAndQuotationIdSpec(req.ProductId, req.QuotationId), ct);

        if (quotationProduct == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        await quotationProductsRepository.DeleteAsync(quotationProduct, ct);
        
        await Send.NoContentAsync(ct);
    }
}