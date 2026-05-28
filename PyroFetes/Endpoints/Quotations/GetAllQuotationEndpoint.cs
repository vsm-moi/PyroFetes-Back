using FastEndpoints;
using PyroFetes.DTO.Quotation.Response;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Quotations;

namespace PyroFetes.Endpoints.Quotations;

public class GetAllQuotationEndpoint(QuotationsRepository quotationsRepository) : EndpointWithoutRequest<List<GetQuotationDto>>
{
    public override void Configure()
    {
        Get("/quotations");
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(await quotationsRepository.ProjectToListAsync<GetQuotationDto>(new GetAllQuotationSpec(), ct), ct);
    }
}