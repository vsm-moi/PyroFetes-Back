using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.QuotationProduct.Request;
using PyroFetes.DTO.QuotationProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.QuotationProducts;

namespace PyroFetes.Endpoints.QuotationProducts;

public class PatchQuotationProductQuantityEndpoint(
    QuotationProductsRepository quotationProductsRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchQuotationProductQuantityDto, GetQuotationProductDto>
{
    public override void Configure()
    {
        Patch("/api/quotationProduct/{@ProductId}/{@QuotationId}/Quantity", x => new { x.ProductId, x.QuotationId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchQuotationProductQuantityDto req, CancellationToken ct)
    {
        QuotationProduct? quotationProduct =
            await quotationProductsRepository.FirstOrDefaultAsync(
                new GetQuotationProductByProductIdAndQuotationIdSpec(req.ProductId, req.QuotationId), ct);
        if (quotationProduct == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        quotationProduct.Quantity = req.Quantity;
        await quotationProductsRepository.UpdateAsync(quotationProduct, ct);
        
        await Send.OkAsync(mapper.Map<GetQuotationProductDto>(quotationProduct), ct);
    }
}