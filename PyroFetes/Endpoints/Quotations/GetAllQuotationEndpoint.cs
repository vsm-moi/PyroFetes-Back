using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Quotation.Response;
using PyroFetes.DTO.QuotationProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Quotations;

public class GetAllQuotationEndpoint(QuotationsRepository quotationsRepository) : EndpointWithoutRequest<List<GetQuotationDto>>
{
    public override void Configure()
    {
        Get("/api/quotations");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(await quotationsRepository.ProjectToListAsync<GetQuotationDto>(ct), ct);
    }
}