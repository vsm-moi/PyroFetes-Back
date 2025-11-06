using FastEndpoints;
using PyroFetes.DTO.Deliverer.Request;
using PyroFetes.DTO.Deliverer.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Deliverers;

public class CreateDelivererEndpoint(PyroFetesDbContext database) : Endpoint<CreateDelivererDto, GetDelivererDto>
{
    public override void Configure()
    {
        Post("api/deliverers");
        AllowAnonymous();

    }

    public override async Task HandleAsync(CreateDelivererDto req, CancellationToken ct)
    {
        Deliverer newDeliverer = new Deliverer()
        {
            Transporter = req.Transporter,
        };
        
        database.Deliverers.Add(newDeliverer);
        
        await database.SaveChangesAsync(ct);

        await Send.OkAsync(new GetDelivererDto()
        {
            Id = newDeliverer.Id,
            Transporter = req.Transporter,
        },ct);
    }
}
