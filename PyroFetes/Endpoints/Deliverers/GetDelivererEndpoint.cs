using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Deliverer.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Deliverers;

namespace PyroFetes.Endpoints.Deliverers;

public class GetDelivererRequest
{
    public int DelivererId { get; set; }
}

public class GetDelivererEndpoint(
    DeliverersRepository deliverersRepository,
    AutoMapper.IMapper mapper) : Endpoint<GetDelivererRequest, GetDelivererDto>
{
    public override void Configure()
    {
        Get("/deliverers/{@id}", x=>new {x.DelivererId});
        AllowAnonymous();

    }

    public override async Task HandleAsync(GetDelivererRequest req, CancellationToken ct)
    {
        Deliverer? deliverer = await deliverersRepository.FirstOrDefaultAsync(new GetDelivererByIdSpec(req.DelivererId), ct);

        if (deliverer == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await Send.OkAsync(mapper.Map<GetDelivererDto>(deliverer), ct);
    }

}