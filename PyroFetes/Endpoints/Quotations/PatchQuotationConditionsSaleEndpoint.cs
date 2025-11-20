using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Quotation.Request;
using PyroFetes.DTO.Quotation.Response;
using PyroFetes.DTO.QuotationProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Quotations;

namespace PyroFetes.Endpoints.Quotations;

public class PatchQuotationConditionsSaleEndpoint(
    QuotationsRepository quotationsRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchQuotationConditionsSaleDto, GetQuotationDto>
{
    public override void Configure()
    {
        Patch("/api/quotations/{@Id}/ConditionsSale", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchQuotationConditionsSaleDto req, CancellationToken ct)
    {
        Quotation? quotation = await quotationsRepository.FirstOrDefaultAsync(new GetQuotationByIdSpec(req.Id), ct);
        
        if (quotation == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        quotation.ConditionsSale = req.ConditionsSale;
        await quotationsRepository.UpdateAsync(quotation, ct);

        
        await Send.OkAsync(mapper.Map<GetQuotationDto>(quotation), ct);
    }
}