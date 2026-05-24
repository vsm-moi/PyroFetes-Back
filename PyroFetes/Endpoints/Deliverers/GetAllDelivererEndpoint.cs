using FastEndpoints;
using PyroFetes.DTO.Deliverer.Response;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Deliverers;

public class GetAllDelivererEndpoint(DeliverersRepository deliverersRepository) : EndpointWithoutRequest<List<GetDelivererDto>>
{
    public override void Configure()
    {
        Get("/deliverers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(await deliverersRepository.ProjectToListAsync<GetDelivererDto>(ct), ct);
    }
}