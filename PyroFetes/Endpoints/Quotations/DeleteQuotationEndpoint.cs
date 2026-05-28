using FastEndpoints;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Quotations;

namespace PyroFetes.Endpoints.Quotations;

public class DeleteQuotationRequest
{
    public int Id { get; set; }
}

public class DeleteQuotationEndpoint(QuotationsRepository quotationsRepository) : Endpoint<DeleteQuotationRequest>
{
    public override void Configure()
    {
        Delete("/quotations/{@Id}", x => new { x.Id });
        Roles("Admin");

    }

    public override async Task HandleAsync(DeleteQuotationRequest req, CancellationToken ct)
    {
        Quotation? quotation = await quotationsRepository.SingleOrDefaultAsync(new GetQuotationByIdSpec(req.Id), ct);

        if (quotation is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await quotationsRepository.DeleteAsync(quotation, ct);
        await Send.NoContentAsync(ct);
    }
}