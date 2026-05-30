using FastEndpoints;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.QuotationProducts;

namespace PyroFetes.Endpoints.Quotations;

public class DeleteQuotationProductRequest
{
    public int ProductId { get; set; }
    public int QuotationId { get; set; }
}

public class DeleteProductFromQuotationEndpoint(QuotationProductsRepository quotationProductsRepository) : Endpoint<DeleteQuotationProductRequest>
{
    public override void Configure()
    {
        Delete("/quotations/{@ProductId}/{@QuotationId}", x => new { x.ProductId, x.QuotationId });
        Roles("Admin");
    }

    public override async Task HandleAsync(DeleteQuotationProductRequest req, CancellationToken ct)
    {
        QuotationProduct? quotationProduct =
            await quotationProductsRepository.SingleOrDefaultAsync(new GetQuotationProductByProductIdAndQuotationIdSpec(req.ProductId, req.QuotationId), ct);

        if (quotationProduct is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await quotationProductsRepository.DeleteAsync(quotationProduct, ct);
        await Send.NoContentAsync(ct);
    }
}