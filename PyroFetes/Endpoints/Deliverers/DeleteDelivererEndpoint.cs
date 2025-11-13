using FastEndpoints;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Deliverers;

namespace PyroFetes.Endpoints.Deliverers;

public class DeleteDelivererRequest
{
    public int DelivererId { get; set; }
}
public class DeleteDelivererEndpoint(DeliverersRepository deliverersRepository) : Endpoint<DeleteDelivererRequest>
{
    public override void Configure()
    {
        Delete("api/deliverers/{@id}", x=>new {x.DelivererId});
        AllowAnonymous();

    }

    public override async Task HandleAsync(DeleteDelivererRequest req, CancellationToken ct)
    {
        Deliverer? deliverer = await deliverersRepository.FirstOrDefaultAsync(new GetDelivererByIdSpec(req.DelivererId), ct);

        if (deliverer == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        await deliverersRepository.DeleteAsync(deliverer, ct);

        await Send.OkAsync(ct);
    }

}