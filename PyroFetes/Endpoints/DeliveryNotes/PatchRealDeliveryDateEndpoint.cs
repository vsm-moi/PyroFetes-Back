using FastEndpoints;
using PyroFetes.DTO.DeliveryNote.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.DeliveryNotes;

namespace PyroFetes.Endpoints.DeliveryNotes;

public class PatchRealDeliveryDateEndpoint(
    DeliveryNotesRepository deliveryNotesRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchDeliveryNoteRealDeliveryDateDto>
{
    public override void Configure()
    {
        Patch("/deliveryNotes/{@Id}", x => new { x.Id });
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(PatchDeliveryNoteRealDeliveryDateDto req, CancellationToken ct)
    {
        DeliveryNote? deliveryNoteToPath = await deliveryNotesRepository.SingleOrDefaultAsync(new GetDeliveryNoteByIdSpec(req.Id), ct);

        if (deliveryNoteToPath is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        if (deliveryNoteToPath.RealDeliveryDate is not null)
        {
            await Send.StringAsync("Impossible de modifier la date.", 400, cancellation: ct);
            return;
        }

        mapper.Map(req, deliveryNoteToPath);

        await deliveryNotesRepository.UpdateAsync(deliveryNoteToPath, ct);

        await Send.NoContentAsync(ct);
    }
}