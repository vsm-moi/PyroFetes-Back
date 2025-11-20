using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.QuotationProduct.Request;
using PyroFetes.DTO.QuotationProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Products;
using PyroFetes.Specifications.Quotations;

namespace PyroFetes.Endpoints.QuotationProducts;

public class CreateQuotationProductEndpoint(
    QuotationProductsRepository quotationProductsRepository,
    ProductsRepository productsRepository,
    QuotationsRepository quotationsRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreateQuotationProductDto, GetQuotationProductDto>
{
    public override void Configure()
    {
        Post("/api/quotationProduct");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateQuotationProductDto req, CancellationToken ct)
    {
        Product? product = await productsRepository.FirstOrDefaultAsync(new GetProductByIdSpec(req.ProductId), ct);
        
        if (product == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        Quotation? quotation = await quotationsRepository.FirstOrDefaultAsync(new GetQuotationByIdSpec(req.QuotationId), ct);
        
        if (quotation == null)
        {
            quotation = new Quotation()
            {
                Message = req.QuotationMessage ?? "",
                ConditionsSale = req.QuotationConditionsSale,
            };
            
            await quotationsRepository.AddAsync(quotation, ct);
        }
        
        QuotationProduct quotationProduct = new QuotationProduct()
        {
            ProductId = product.Id,
            QuotationId = quotation.Id,
            Quantity = req.Quantity
        };
        
        await quotationProductsRepository.AddAsync(quotationProduct, ct);

        await Send.OkAsync(mapper.Map<GetQuotationProductDto>(quotationProduct), ct);
    }
}
