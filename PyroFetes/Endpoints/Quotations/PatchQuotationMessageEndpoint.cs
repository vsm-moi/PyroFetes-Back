using FastEndpoints;
using PyroFetes.DTO.Quotation.Request;
using PyroFetes.DTO.Quotation.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Quotations;

namespace PyroFetes.Endpoints.Quotations;

public class PatchQuotationMessageEndpoint(
    QuotationsRepository quotationsRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchQuotationMessageDto>
{
    public override void Configure()
    {
        Patch("/quotations/{@Id}/message", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchQuotationMessageDto req, CancellationToken ct)
    {
        Quotation? quotation = await quotationsRepository.SingleOrDefaultAsync(new GetQuotationByIdSpec(req.Id), ct);

        if (quotation is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        mapper.Map(req, quotation);
        
        await quotationsRepository.SaveChangesAsync(ct);
        await Send.NoContentAsync(ct);
    }
}