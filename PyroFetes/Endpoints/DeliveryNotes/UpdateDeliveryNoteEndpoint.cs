using FastEndpoints;
using PyroFetes.DTO.DeliveryNote.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.DeliveryNotes;

namespace PyroFetes.Endpoints.DeliveryNotes;

public class UpdateDeliveryNoteEndpoint(DeliveryNotesRepository deliveryNotesRepository, AutoMapper.IMapper mapper) : Endpoint<UpdateDeliveryNoteDto>
{
    public override void Configure()
    {
        Put("/deliveryNotes/{@Id}", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateDeliveryNoteDto req, CancellationToken ct)
    {
        DeliveryNote? deliveryNote = await deliveryNotesRepository.SingleOrDefaultAsync(new GetDeliveryNoteByIdSpec(req.Id), ct);

        if (deliveryNote is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        mapper.Map(req, deliveryNote);

        await deliveryNotesRepository.SaveChangesAsync(ct);
        await Send.NoContentAsync(ct);
    }
}