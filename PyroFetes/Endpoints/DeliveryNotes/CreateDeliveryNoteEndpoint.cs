using FastEndpoints;
using PyroFetes.DTO.DeliveryNote.Request;
using PyroFetes.DTO.DeliveryNote.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Deliverers;
using PyroFetes.Specifications.Products;

namespace PyroFetes.Endpoints.DeliveryNotes;

public class CreateDeliveryNoteEndpoint(
    DeliveryNotesRepository deliveryNotesRepository,
    DeliverersRepository deliverersRepository,
    ProductsRepository productsRepository,
    ProductDeliveriesRepository productDeliveriesRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreateDeliveryNoteDto, GetDeliveryNoteDto>
{
    public override void Configure()
    {
        Post("/api/DeliveryNote");
    }

    public override async Task HandleAsync(CreateDeliveryNoteDto req, CancellationToken ct)
    {
        Deliverer? deliverer = await deliverersRepository.FirstOrDefaultAsync(new GetDelivererByIdSpec(req.DelivererId), ct);
        
        if (deliverer == null)
        {
            await Send.StringAsync("No deliverer found", 404, cancellation: ct);
            return;
        }
        
        //Creating the Delivery Note
        DeliveryNote newDeliveryNote = new DeliveryNote()
        {
            TrackingNumber = req.TrackingNumber,
            EstimateDeliveryDate = req.EstimateDeliveryDate,
            ExpeditionDate =  req.ExpeditionDate,
            DelivererId = req.DelivererId,
            Deliverer = deliverer,
            
        };
        
        await deliveryNotesRepository.AddAsync(newDeliveryNote, ct);

        foreach (var productQuantity in req.ProductQuantities!)
        {
            Models.Product? product =
                await productsRepository.FirstOrDefaultAsync(new GetProductByIdSpec(productQuantity.Key), ct);
            if (product != null)
            {
                ProductDelivery productDelivery = new ProductDelivery()
                {
                    DeliveryNote = newDeliveryNote,
                    Quantity = productQuantity.Value,
                    Product = product,
                    DeliveryNoteId = newDeliveryNote.Id
                };
                
                await productDeliveriesRepository.AddAsync(productDelivery, ct);
            }

        }
        
        await Send.OkAsync(mapper.Map<GetDeliveryNoteDto>(newDeliveryNote), ct);
    }
}