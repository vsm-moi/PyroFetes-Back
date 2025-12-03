using FastEndpoints;
using PyroFetes.DTO.PurchaseOrder.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Services.Pdf;
using PyroFetes.Specifications.PurchaseOrders;
namespace PyroFetes.Endpoints.PurchaseOrders;

public class GetPurchaseOrderPdfEndpoint(
    PurchaseOrdersRepository purchaseOrdersRepository,
    IPurchaseOrderPdfService purchaseOrderPdfService) 
    : Endpoint<GetPurchaseOrderPdfDto>
{
    public override void Configure()
    {
        Get("/purchaseOrders/{@Id}/pdf", x => new {x.Id});
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GetPurchaseOrderPdfDto req, CancellationToken ct)
    {
        PurchaseOrder? purchaseOrder = await purchaseOrdersRepository
            .FirstOrDefaultAsync(new GetPurchaseOrderByIdWithProductsSpec(req.Id), ct);

        if (purchaseOrder == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        var bytes = purchaseOrderPdfService.Generate(purchaseOrder, purchaseOrder.PurchaseProducts!);

        await Send.BytesAsync(
            bytes: bytes,
            contentType: "application/pdf",
            fileName: $"bon-de-commande-{purchaseOrder.Id}.pdf",
            cancellation: ct);
    }
}