using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Quotations;

namespace PyroFetes.Endpoints.Quotations;

public class DeleteQuotationRequest
{
    public int Id { get; set; }
}

public class DeleteQuotationEndpoint(
    QuotationsRepository quotationsRepository,
    QuotationProductsRepository quotationProductsRepository) : Endpoint<DeleteQuotationRequest>
{
    public override void Configure()
    {
        Delete("/api/quotations/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteQuotationRequest req, CancellationToken ct)
    {
        Quotation? quotation = await quotationsRepository.FirstOrDefaultAsync(new GetQuotationByIdSpec(req.Id), ct);

        if (quotation == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        if (quotation.QuotationProducts != null && quotation.QuotationProducts.Any())
        {
            await quotationProductsRepository.DeleteRangeAsync(quotation.QuotationProducts, ct);
        }
        
        await quotationsRepository.DeleteAsync(quotation, ct);
        
        await Send.NoContentAsync(ct);
    }
}