using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.QuotationProduct.Request;
using PyroFetes.DTO.QuotationProduct.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.QuotationProducts;

public class PatchQuotationProductQuantityEndpoint(PyroFetesDbContext database) : Endpoint<PatchQuotationProductQuantityDto, GetQuotationProductDto>
{
    public override void Configure()
    {
        Patch("/api/quotationProduct/{@ProductId}/{@QuotationId}/Quantity", x => new { x.ProductId, x.QuotationId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchQuotationProductQuantityDto req, CancellationToken ct)
    {
        QuotationProduct? quotationProduct = await database.QuotationProducts.SingleOrDefaultAsync(qo => qo.ProductId == req.ProductId && qo.QuotationId == req.QuotationId, ct);
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