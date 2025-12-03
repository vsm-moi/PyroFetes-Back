using FastEndpoints;
using PyroFetes.DTO.DeliveryNote.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Services.Pdf;
using PyroFetes.Specifications.DeliveryNotes;
using PyroFetes.Specifications.Quotations;

namespace PyroFetes.Endpoints.DeliveryNotes;

public class GetDeliveryNotePdfEndpoint(
    DeliveryNotesRepository deliveryNotesRepository,
    IDeliveryNotePdfService deliveryNotePdfService)
    : Endpoint<GetDeliveryNotePdfDto>
{
    public override void Configure()
    {
        Get("/deliveryNotes/{@Id}/pdf", x => new {x.Id});
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GetDeliveryNotePdfDto req, CancellationToken ct)
    {
        DeliveryNote? deliveryNote = await deliveryNotesRepository
            .FirstOrDefaultAsync(new GetDeliveryNoteByIdWithProductsSpec(req.Id), ct);

        if (deliveryNote == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        var bytes = deliveryNotePdfService.Generate(deliveryNote, deliveryNote.ProductDeliveries!);

        await Send.BytesAsync(
            bytes: bytes,
            contentType: "application/pdf",
            fileName: $"bon-de-livraison-{deliveryNote.Id}.pdf",
            cancellation: ct);
    }
}