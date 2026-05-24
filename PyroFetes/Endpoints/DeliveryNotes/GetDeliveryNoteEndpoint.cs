using FastEndpoints;
using PyroFetes.DTO.DeliveryNote.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.DeliveryNotes;

namespace PyroFetes.Endpoints.DeliveryNotes;

public class GetDeliveryNoteRequest
{
    public int DeliveryNoteId { get; set; }
}

public class GetDeliveryNoteEndpoint(
    DeliveryNotesRepository deliveryNotesRepository,
    AutoMapper.IMapper mapper) : Endpoint<GetDeliveryNoteRequest, GetDeliveryNoteDto>
{
    public override void Configure()
    {
        Get("/deliveryNotes/{@Id}", x => new { x.DeliveryNoteId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetDeliveryNoteRequest req, CancellationToken ct)
    {
        DeliveryNote? deliveryNote = await deliveryNotesRepository.SingleOrDefaultAsync(new GetDeliveryNoteByIdSpec(req.DeliveryNoteId), ct);

        if (deliveryNote is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await Send.OkAsync(mapper.Map<GetDeliveryNoteDto>(deliveryNote), ct);
    }
}