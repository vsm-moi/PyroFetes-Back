using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Deliverer.Request;
using PyroFetes.DTO.Deliverer.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Deliverers;

public class UpdateDelivererEndpoint(
    PyroFetesDbContext database,
    AutoMapper.IMapper mapper) : Endpoint<UpdateDelivererDto, GetDelivererDto>
{
    public override void Configure()
    {
        Put("api/deliverers/{@id}", x=>new {x.Id});
        AllowAnonymous();

    }

    public override async Task HandleAsync(UpdateDelivererDto req, CancellationToken ct)
    {
        Deliverer? deliverer = await database.Deliverers.SingleOrDefaultAsync(x=>x.Id == req.Id, ct);

        if (deliverer == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        deliverer.Transporter = req.Transporter;
        
        await database.SaveChangesAsync(ct);

        await Send.OkAsync(mapper.Map<GetDelivererDto>(deliverer), ct);
    }

}