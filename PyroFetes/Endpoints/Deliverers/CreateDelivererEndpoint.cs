using FastEndpoints;
using PyroFetes.DTO.Deliverer.Request;
using PyroFetes.DTO.Deliverer.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Deliverers;

public class CreateDelivererEndpoint(
    DeliverersRepository deliverersRepository, 
    AutoMapper.IMapper mapper) : Endpoint<CreateDelivererDto, GetDelivererDto>
{
    public override void Configure()
    {
        Post("/deliverers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateDelivererDto req, CancellationToken ct)
    {
        Deliverer newDeliverer = new Deliverer()
        {
            Transporter = req.Transporter,
        };

        await deliverersRepository.AddAsync(newDeliverer, ct);

        await Send.OkAsync(mapper.Map<GetDelivererDto>(newDeliverer), ct);
    }
}
