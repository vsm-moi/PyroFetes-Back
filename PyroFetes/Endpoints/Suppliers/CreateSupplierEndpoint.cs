using FastEndpoints;
using PyroFetes.DTO.Supplier.Request;
using PyroFetes.DTO.Supplier.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Suppliers;

public class CreateSupplierEndpoint(
    SuppliersRepository suppliersRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreateSupplierDto, GetSupplierDto>
{
    public override void Configure()
    {
        Post("/api/suppliers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateSupplierDto req, CancellationToken ct)
    {
        Supplier? supplier = new Supplier()
        {
            Name = req.Name,
            Email = req.Email,
            Phone = req.Phone,
            Address = req.Address,
            City = req.City,
            ZipCode = req.ZipCode,
            DeliveryDelay = req.DeliveryDelay
        };
        
        await suppliersRepository.AddAsync(supplier, ct);

        await Send.OkAsync(mapper.Map<GetSupplierDto>(supplier), ct);
    }
}