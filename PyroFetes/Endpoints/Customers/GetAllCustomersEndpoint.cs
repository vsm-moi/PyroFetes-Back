using FastEndpoints;
using PyroFetes.DTO.Customer.Response;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Customers;

public class GetAllCustomersEndpoint(CustomersRepository customersRepository, AutoMapper.IMapper mapper) : EndpointWithoutRequest<List<GetCustomerDto>>
{
    public override void Configure()
    {
        Get("/customers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(await customersRepository.ProjectToListAsync<GetCustomerDto>(ct), ct);
    }
}