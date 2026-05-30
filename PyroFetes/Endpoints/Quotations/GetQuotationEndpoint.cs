using FastEndpoints;
using PyroFetes.DTO.Quotation.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Quotations;

namespace PyroFetes.Endpoints.Quotations;

public class GetQuotationRequest
{
    public int Id { get; set; }
}

public class GetQuotationEndpoint(
    QuotationsRepository quotationsRepository,
    AutoMapper.IMapper mapper) : Endpoint<GetQuotationRequest, GetQuotationDto>
{
    public override void Configure()
    {
        Get("/quotations/{@Id}", x => new { x.Id });
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(GetQuotationRequest req, CancellationToken ct)
    {
        Quotation? quotation = await quotationsRepository.SingleOrDefaultAsync(new GetQuotationByIdSpec(req.Id), ct);

        if (quotation is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await Send.OkAsync(mapper.Map<GetQuotationDto>(quotation), ct);
    }
}