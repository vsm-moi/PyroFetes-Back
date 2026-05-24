using FastEndpoints;
using PyroFetes.DTO.DeliveryNote.Response;
using PyroFetes.Repositories;
using PyroFetes.Specifications.DeliveryNotes;

namespace PyroFetes.Endpoints.DeliveryNotes;

public class GetAllDeliveryNoteEndpoint(DeliveryNotesRepository deliveryNotesRepository) : EndpointWithoutRequest<List<GetDeliveryNoteDto>>
{
    public override void Configure()
    {
        Get("/deliveryNotes");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(await deliveryNotesRepository.ProjectToListAsync<GetDeliveryNoteDto>(new GetAllDeliveryNoteSpec(), ct), ct);
    }
}