using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using PyroFetes.DTO.Deliverer.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Deliverers;

public class GetAllDelivererEndpoint(PyroFetesDbContext database) : EndpointWithoutRequest<List<GetDelivererDto>>
{
    public override void Configure()
    {
        Get("api/deliverers");
        AllowAnonymous();

    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        List<GetDelivererDto> deliverers = await database.Deliverers.Select(x => new GetDelivererDto()
        {
            Id = x.Id,
            Transporter = x.Transporter,
        }).ToListAsync(ct);
        
        await Send.OkAsync(deliverers, ct);
    }

}