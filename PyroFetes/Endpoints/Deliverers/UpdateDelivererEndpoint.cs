using FastEndpoints;
using PyroFetes.DTO.Deliverer.Request;
using PyroFetes.DTO.Deliverer.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Deliverers;

namespace PyroFetes.Endpoints.Deliverers;

public class UpdateDelivererEndpoint(DeliverersRepository deliverersRepository, AutoMapper.IMapper mapper) : Endpoint<UpdateDelivererDto, GetDelivererDto>
{
    public override void Configure()
    {
        Put("/deliverers/{@Id}", x => new { x.Id });
        Roles("Admin", "Employe");
    }

    public override async Task HandleAsync(UpdateDelivererDto req, CancellationToken ct)
    {
        Deliverer? deliverer = await deliverersRepository.SingleOrDefaultAsync(new GetDelivererByIdSpec(req.Id), ct);

        if (deliverer is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        mapper.Map(req, deliverer);

        await deliverersRepository.SaveChangesAsync(ct);
        await Send.NoContentAsync(ct);
    }
}