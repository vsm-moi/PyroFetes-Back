using FastEndpoints;
using PyroFetes.DTO.Deliverer.Request;
using PyroFetes.DTO.Deliverer.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Deliverers;

public class CreateDelivererEndpoint(DeliverersRepository deliverersRepository) : Endpoint<CreateDelivererDto, GetDelivererDto>
{
    public override void Configure()
    {
        Post("/deliverers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateDelivererDto req, CancellationToken ct)
    {
        Deliverer newDeliverer = new()
        {
            Transporter = req.Transporter,
        };

        await deliverersRepository.AddAsync(newDeliverer, ct);
        await Send.NoContentAsync(ct);
    }
}