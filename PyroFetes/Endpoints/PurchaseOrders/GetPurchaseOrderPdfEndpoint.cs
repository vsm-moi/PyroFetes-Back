using System.Net.Mime;
using FastEndpoints;
using PyroFetes.DTO.PurchaseOrder.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Services.Pdf;
using PyroFetes.Specifications.PurchaseOrders;

namespace PyroFetes.Endpoints.PurchaseOrders;

public class GetPurchaseOrderPdfEndpoint(
    PurchaseOrdersRepository purchaseOrdersRepository,
    IPurchaseOrderPdfService purchaseOrderPdfService,
    SettingsRepository settingsRepository)
    : Endpoint<GetPurchaseOrderPdfDto, byte[]>
{
    public override void Configure()
    {
        Get("/purchaseOrders/{@Id}/pdf", x => new { x.Id });
        Roles("Admin","Employe");
        Description(b => b.Produces<byte[]>(200, MediaTypeNames.Application.Pdf));
    }

    public override async Task HandleAsync(GetPurchaseOrderPdfDto req, CancellationToken ct)
    {
        PurchaseOrder? purchaseOrder = await purchaseOrdersRepository.SingleOrDefaultAsync(new GetPurchaseOrderByIdWithProductsSpec(req.Id), ct);

        if (purchaseOrder is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        Setting? setting = await settingsRepository.FirstOrDefaultAsync(ct);

        byte[] bytes = purchaseOrderPdfService.Generate(purchaseOrder, purchaseOrder.PurchaseProducts!, setting!);

        await Send.BytesAsync(
            bytes: bytes,
            contentType: "application/pdf",
            fileName: $"bon-de-commande-{purchaseOrder.Id}{DateOnly.FromDateTime(DateTime.Now)}.pdf",
            cancellation: ct);
    }
}