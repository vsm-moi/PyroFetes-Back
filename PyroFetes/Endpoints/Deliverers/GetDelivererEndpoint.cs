using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Deliverer.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Deliverers;

public class GetDelivererRequest
{
    public int DelivererId { get; set; }
}

public class GetDelivererEndpoint(
    PyroFetesDbContext database,
    AutoMapper.IMapper mapper) : Endpoint<GetDelivererRequest, GetDelivererDto>
{
    public override void Configure()
    {
        Get("api/deliverers/{@id}", x=>new {x.DelivererId});
        AllowAnonymous();

    }

    public override async Task HandleAsync(GetDelivererRequest req, CancellationToken ct)
    {
        Deliverer? deliverer = await database.Deliverers.SingleOrDefaultAsync(x=>x.Id == req.DelivererId, ct);

        if (deliverer == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await Send.OkAsync(mapper.Map<GetDelivererDto>(deliverer), ct);
    }

}