using System.Net.Mime;
using FastEndpoints;
using PyroFetes.DTO.Quotation.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Services;
using PyroFetes.Services.Pdf;
using PyroFetes.Specifications.Quotations;

namespace PyroFetes.Endpoints.Quotations;

public class GetQuotationPdfEndpoint(
    QuotationsRepository quotationRepository,
    QuotationPdfService quotationPdfService,
    SettingsRepository settingsRepository,
    StorageService storageService)
    : Endpoint<GetQuotationPdfDto, byte[]>
{
    public override void Configure()
    {
        Get("/quotations/{@Id}/pdf", x => new { x.Id });
        Roles("Admin","Employe");
        Description(b => b.Produces<byte[]>(200, MediaTypeNames.Application.Pdf));
    }

    public override async Task HandleAsync(GetQuotationPdfDto req, CancellationToken ct)
    {
        Quotation? quotation = await quotationRepository.SingleOrDefaultAsync(new GetQuotationByIdWithProductsSpec(req.Id), ct);

        if (quotation is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        Setting? setting = await settingsRepository.FirstOrDefaultAsync(ct);

        byte[] bytes = await quotationPdfService.Generate(quotation, setting!, storageService);

        await Send.BytesAsync(
            bytes: bytes,
            contentType: "application/pdf",
            fileName: $"devis-{quotation.Id}{DateOnly.FromDateTime(DateTime.Now)}.pdf",
            cancellation: ct);
    }
}