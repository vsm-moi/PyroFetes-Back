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
        Delete("/deliverers/{@Id}", x => new { x.DelivererId });
        Roles("Admin");
    }

    public override async Task HandleAsync(DeleteDelivererRequest req, CancellationToken ct)
    {
        Deliverer? deliverer = await deliverersRepository.SingleOrDefaultAsync(new GetDelivererByIdSpec(req.DelivererId), ct);

        if (deliverer is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await deliverersRepository.DeleteAsync(deliverer, ct);
        await Send.NoContentAsync(ct);
    }
}