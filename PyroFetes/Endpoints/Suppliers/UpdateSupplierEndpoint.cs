using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Supplier.Request;
using PyroFetes.DTO.Supplier.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Suppliers;

namespace PyroFetes.Endpoints.Suppliers;

public class UpdateSupplierEndpoint(
    SuppliersRepository suppliersRepository,
    AutoMapper.IMapper mapper) : Endpoint<UpdateSupplierDto, GetSupplierDto>
{
    public override void Configure()
    {
        Put("/suppliers/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateSupplierDto req, CancellationToken ct)
    {
        Supplier? supplier = await suppliersRepository.FirstOrDefaultAsync(new GetSupplierByIdSpec(req.Id), ct);
        
        if (supplier == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        supplier.Name = req.Name;
        supplier.Email = req.Email;
        supplier.Phone = req.Phone;
        supplier.Address = req.Address;
        supplier.City = req.City;
        supplier.ZipCode = req.ZipCode;
        supplier.DeliveryDelay = req.DeliveryDelay;
        
        await suppliersRepository.UpdateAsync(supplier, ct);
        
        await Send.OkAsync(mapper.Map<GetSupplierDto>(supplier), ct);
    }
}