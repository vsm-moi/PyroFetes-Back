using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.QuotationProduct.Request;
using PyroFetes.DTO.QuotationProduct.Response;

namespace PyroFetes.Endpoints.QuoationProduct;

public class PatchQuotationProductQuantityEndpoint(PyroFetesDbContext database) : Endpoint<PatchQuotationProductQuantityDto, GetQuotationProductDto>
{
    public override void Configure()
    {
        Patch("/api/quotationProduct/{ProductId}/{QuotationId}/Quantity", x => new { x.ProductId, x.QuotationId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchQuotationProductQuantityDto req, CancellationToken ct)
    {
        var quotationProduct = await database.QuotationProducts.SingleOrDefaultAsync(qo => qo.ProductId == req.ProductId && qo.QuotationId == req.QuotationId, ct);
        if (quotationProduct == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        quotationProduct.Quantity = req.Quantity;
        await database.SaveChangesAsync(ct);

        GetQuotationProductDto responseDto = new()
        {
            ProductId = quotationProduct.ProductId,
            QuotationId = quotationProduct.QuotationId,
            Quantity = quotationProduct.Quantity
        };
        await Send.OkAsync(responseDto, ct);
    }
}