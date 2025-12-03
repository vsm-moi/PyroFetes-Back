using FastEndpoints;
using PyroFetes.DTO.Quotation.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Services.Pdf;
using PyroFetes.Specifications.Quotations;

namespace PyroFetes.Endpoints.Quotations;

public class GetQuotationPdfEndpoint(
    QuotationsRepository quotationRepository,
    QuotationProductsRepository quotationProductRepository, 
    IQuotationPdfService quotationPdfService) 
    : Endpoint<GetQuotationPdfDto>
{
    public override void Configure()
    {
        Get("/quotations/{@Id}/pdf", x => new {x.Id});
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GetQuotationPdfDto req, CancellationToken ct)
    {
        Quotation? quotation = await quotationRepository
            .FirstOrDefaultAsync(new GetQuotationByIdWithProductsSpec(req.Id), ct);

        if (quotation == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        var bytes = quotationPdfService.Generate(quotation, quotation.QuotationProducts!);

        await Send.BytesAsync(
            bytes: bytes,
            contentType: "application/pdf",
            fileName: $"devis-{quotation.Id}.pdf",
            cancellation: ct);
    }
}