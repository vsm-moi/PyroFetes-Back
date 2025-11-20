using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Quotation.Response;
using PyroFetes.DTO.QuotationProduct.Response;
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
        Get("/api/quotations/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetQuotationRequest req, CancellationToken ct)
    {
        Quotation? quotation = await quotationsRepository.FirstOrDefaultAsync(new GetQuotationByIdSpec(req.Id), ct);

        if (quotation == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        await Send.OkAsync(mapper.Map<GetQuotationDto>(quotation), ct);
    }
}