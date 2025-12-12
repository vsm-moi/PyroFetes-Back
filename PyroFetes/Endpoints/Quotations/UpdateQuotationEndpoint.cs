using FastEndpoints;
using PyroFetes.DTO.Quotation.Request;
using PyroFetes.DTO.Quotation.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Quotations;

namespace PyroFetes.Endpoints.Quotations;

public class UpdateQuotationEndpoint(
    QuotationsRepository quotationsRepository,
    AutoMapper.IMapper mapper) : Endpoint<UpdateQuotationDto, GetQuotationDto>
{
    public override void Configure()
    {
        Put("/quotations/{@Id}", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateQuotationDto req, CancellationToken ct)
    {
        Quotation? quotation = await quotationsRepository.FirstOrDefaultAsync(new GetQuotationByIdSpec(req.Id), ct);
        
        if (quotation == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        quotation.ConditionsSale = req.ConditionsSale;
        quotation.Message =  req.Message;
        await quotationsRepository.UpdateAsync(quotation, ct);
        
        await Send.OkAsync(mapper.Map<GetQuotationDto>(quotation), ct);
    }
}