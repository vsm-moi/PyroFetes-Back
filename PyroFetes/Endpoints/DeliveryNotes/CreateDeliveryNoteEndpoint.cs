using FastEndpoints;
using PyroFetes.DTO.DeliveryNote.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Deliverers;
using PyroFetes.Specifications.Products;
using PyroFetes.Specifications.Suppliers;

namespace PyroFetes.Endpoints.DeliveryNotes;

public class CreateDeliveryNoteEndpoint(
    DeliveryNotesRepository deliveryNotesRepository,
    DeliverersRepository deliverersRepository,
    ProductsRepository productsRepository,
    SuppliersRepository suppliersRepository,
    ProductDeliveriesRepository productDeliveriesRepository) : Endpoint<CreateDeliveryNoteDto>
{
    public override void Configure()
    {
        Post("/deliveryNotes");
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(CreateDeliveryNoteDto req, CancellationToken ct)
    {
        Deliverer? deliverer = await deliverersRepository.SingleOrDefaultAsync(new GetDelivererByIdSpec(req.DelivererId), ct);
        Supplier? supplier = await suppliersRepository.SingleOrDefaultAsync(new GetSupplierByIdSpec(req.SupplierId), ct);
        if (deliverer is null || supplier is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        //Creating the Delivery Note
        DeliveryNote newDeliveryNote = new()
        {
            TrackingNumber = req.TrackingNumber,
            EstimateDeliveryDate = DateOnly.FromDateTime(DateTime.Today).AddMonths(2),
            ExpeditionDate = DateOnly.FromDateTime(DateTime.Today),
            DelivererId = deliverer.Id,
            Deliverer = deliverer,
            SupplierId = req.SupplierId,
            Supplier = supplier
        };

        await deliveryNotesRepository.AddAsync(newDeliveryNote, ct);

        if (req.ProductQuantities is not null)
        {
            foreach (KeyValuePair<int, int> productQuantity in req.ProductQuantities)
            {
                Product? product = await productsRepository.SingleOrDefaultAsync(new GetProductByIdSpec(productQuantity.Key), ct);
                if (product is null) continue;
                ProductDelivery productDelivery = new()
                {
                    DeliveryNote = newDeliveryNote,
                    Quantity = productQuantity.Value,
                    Product = product,
                    ProductId = product.Id,
                    DeliveryNoteId = newDeliveryNote.Id
                };

                await productDeliveriesRepository.AddAsync(productDelivery, ct);
            }
        }

        await Send.NoContentAsync(ct);
    }
}