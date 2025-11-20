using FastEndpoints;
using PyroFetes.DTO.DeliveryNote.Request;
using PyroFetes.DTO.DeliveryNote.Response;
using PyroFetes.DTO.PurchaseProduct.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Deliverers;
using PyroFetes.Specifications.DeliveryNotes;

namespace PyroFetes.Endpoints.DeliveryNotes;

public class PatchRealDeliveryDateEndpoint(
    DeliveryNotesRepository deliveryNotesRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchDeliveryNoteRealDeliveryDateDto, GetDeliveryNoteDto>
{
    public override void Configure()
    {
        Patch("/api/deliveryNote/{@id}", x=> new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchDeliveryNoteRealDeliveryDateDto req, CancellationToken ct)
    {
        DeliveryNote? deliveryNoteToPath =
            await deliveryNotesRepository.FirstOrDefaultAsync(new GetDeliveryNoteByIdSpec(req.Id),ct);

        if (deliveryNoteToPath == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        deliveryNoteToPath.RealDeliveryDate = req.RealDeliveryDate;
        
        await deliveryNotesRepository.UpdateAsync(deliveryNoteToPath, ct);
        
        await Send.OkAsync(mapper.Map<GetDeliveryNoteDto>(deliveryNoteToPath), ct);
    }
}