using FastEndpoints;
using PyroFetes.DTO.DeliveryNote.Request;
using PyroFetes.DTO.DeliveryNote.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.DeliveryNotes;

namespace PyroFetes.Endpoints.DeliveryNotes;

public class UpdateDeliveryNoteEndpoint(
    DeliveryNotesRepository deliveryNotesRepository,
    AutoMapper.IMapper mapper) : Endpoint<UpdateDeliveryNoteDto, GetDeliveryNoteDto>
{
    public override void Configure()
    {
        Put("/deliveryNotes/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateDeliveryNoteDto req, CancellationToken ct)
    {
        DeliveryNote? deliveryNote = await deliveryNotesRepository.FirstOrDefaultAsync(new GetDeliveryNoteByIdSpec(req.Id), ct);
        
        if (deliveryNote == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        deliveryNote.TrackingNumber = req.TrackingNumber;
        deliveryNote.EstimateDeliveryDate = req.EstimateDeliveryDate;
        deliveryNote.ExpeditionDate = req.ExpeditionDate;
        deliveryNote.RealDeliveryDate = req.RealDeliveryDate;
        deliveryNote.DelivererId = req.DelivererId;
        
        await deliveryNotesRepository.UpdateAsync(deliveryNote, ct);
        
        await Send.OkAsync(mapper.Map<GetDeliveryNoteDto>(deliveryNote), ct);
    }
}