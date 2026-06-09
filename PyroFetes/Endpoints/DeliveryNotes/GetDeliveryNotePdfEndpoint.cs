using System.Net.Mime;
using FastEndpoints;
using PyroFetes.DTO.DeliveryNote.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Services;
using PyroFetes.Services.Pdf;
using PyroFetes.Specifications.DeliveryNotes;

namespace PyroFetes.Endpoints.DeliveryNotes;

public class GetDeliveryNotePdfEndpoint(
    DeliveryNotesRepository deliveryNotesRepository,
    DeliveryNotePdfService deliveryNotePdfService,
    SettingsRepository settingsRepository,
    StorageService storageService)
    : Endpoint<GetDeliveryNotePdfDto, byte[]>
{
    public override void Configure()
    {
        Get("/deliveryNotes/{@Id}/pdf", x => new { x.Id });
        Roles("Admin", "Employe");
        Description(b => b.Produces<byte[]>(200, MediaTypeNames.Application.Pdf));
    }

    public override async Task HandleAsync(GetDeliveryNotePdfDto req, CancellationToken ct)
    {
        DeliveryNote? deliveryNote = await deliveryNotesRepository
            .SingleOrDefaultAsync(new GetDeliveryNoteByIdWithProductsSpec(req.Id), ct);

        Setting? setting = await settingsRepository.FirstOrDefaultAsync(ct);

        if (deliveryNote is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        byte[] bytes = await deliveryNotePdfService.Generate(deliveryNote, setting!, storageService);

        await Send.BytesAsync(
            bytes: bytes,
            contentType: "application/pdf",
            fileName: $"bon-de-livraison-{deliveryNote.Id}{DateOnly.FromDateTime(DateTime.Now)}.pdf",
            cancellation: ct);
    }
}