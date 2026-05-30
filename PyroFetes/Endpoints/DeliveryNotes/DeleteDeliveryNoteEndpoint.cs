using FastEndpoints;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.DeliveryNotes;

namespace PyroFetes.Endpoints.DeliveryNotes;

public class DeleteDeliveryNoteRequest
{
    public int Id { get; set; }
}

public class DeleteDeliveryNoteEndpoint(
    DeliveryNotesRepository deliveryNotesRepository) : Endpoint<DeleteDeliveryNoteRequest>
{
    public override void Configure()
    {
        Delete("/deliveryNotes/{@Id}", x => new { x.Id });
        Roles("Admin");
    }

    public override async Task HandleAsync(DeleteDeliveryNoteRequest req, CancellationToken ct)
    {
        DeliveryNote? deliveryNote = await deliveryNotesRepository.SingleOrDefaultAsync(new GetDeliveryNoteByIdSpec(req.Id), ct);

        if (deliveryNote is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await deliveryNotesRepository.DeleteAsync(deliveryNote, ct);
        await Send.NoContentAsync(ct);
    }
}