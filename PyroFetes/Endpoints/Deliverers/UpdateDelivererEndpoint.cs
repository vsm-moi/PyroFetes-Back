using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Deliverer.Request;
using PyroFetes.DTO.Deliverer.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Deliverers;

namespace PyroFetes.Endpoints.Deliverers;

public class UpdateDelivererEndpoint(
    DeliverersRepository deliverersRepository,
    AutoMapper.IMapper mapper) : Endpoint<UpdateDelivererDto, GetDelivererDto>
{
    public override void Configure()
    {
        Put("/deliverers/{@id}", x=>new {x.Id});
        AllowAnonymous();

    }

    public override async Task HandleAsync(UpdateDelivererDto req, CancellationToken ct)
    {
        Deliverer? deliverer = await deliverersRepository.FirstOrDefaultAsync(new GetDelivererByIdSpec(req.Id), ct);

        if (deliverer == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        deliverer.Transporter = req.Transporter;
        
        await deliverersRepository.UpdateAsync(deliverer,ct);

        await Send.OkAsync(mapper.Map<GetDelivererDto>(deliverer), ct);
    }

}