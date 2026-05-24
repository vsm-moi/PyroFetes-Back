using FastEndpoints;
using PyroFetes.DTO.QuotationProduct.Request;
using PyroFetes.DTO.QuotationProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.QuotationProducts;

namespace PyroFetes.Endpoints.Quotations;

public class PatchQuotationProductQuantityEndpoint(
    QuotationProductsRepository quotationProductsRepository,
    AutoMapper.IMapper mapper) : Endpoint<PatchQuotationProductQuantityDto>
{
    public override void Configure()
    {
        Patch("/quotations/{@ProductId}/{@QuotationId}/Quantity", x => new { x.ProductId, x.QuotationId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchQuotationProductQuantityDto req, CancellationToken ct)
    {
        QuotationProduct? quotationProduct =
            await quotationProductsRepository.SingleOrDefaultAsync(new GetQuotationProductByProductIdAndQuotationIdSpec(req.ProductId, req.QuotationId), ct);
        if (quotationProduct is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        mapper.Map(req, quotationProduct);
        
        await quotationProductsRepository.SaveChangesAsync(ct);
        await Send.NoContentAsync(ct);
    }
}