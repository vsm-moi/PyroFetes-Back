using FastEndpoints;
using PyroFetes.DTO.WareHouse.Response;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints;

public class GetAllWarehouseEndpoint(WareHouseRepository wareHouseRepository, AutoMapper.IMapper mapper) : EndpointWithoutRequest<List<GetWareHouseDto>>
{
    public override void Configure()
    {
        Get("/wareHouses/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(await wareHouseRepository.ProjectToListAsync<GetWareHouseDto>(ct), ct);
    }
}