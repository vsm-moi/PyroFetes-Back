using FastEndpoints;
using PyroFetes.DTO.QuotationProduct.Request;
using PyroFetes.DTO.QuotationProduct.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.QuotationProducts;

namespace PyroFetes.Endpoints.Quotations;

public class AddProductoToQuotationEndpoint(
    QuotationProductsRepository quotationProductsRepository,
    AutoMapper.IMapper mapper) : Endpoint<AddQuotationProductDto>
{
    public override void Configure()
    {
        Post("/quotations/{@Id}/products", x => new { x.ProductId, x.QuotationId });
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddQuotationProductDto req, CancellationToken ct)
    {
        QuotationProduct? productQuotation =
            await quotationProductsRepository.SingleOrDefaultAsync(new GetQuotationProductByProductIdAndQuotationIdSpec(req.ProductId, req.QuotationId), ct);

        if (productQuotation is not null)
        {
            await Send.StringAsync("ce produit existe déjà dans le devis", 400, cancellation: ct);
            return;
        }

        QuotationProduct quotationProduct = mapper.Map<QuotationProduct>(req);

        await quotationProductsRepository.AddAsync(quotationProduct, ct);
        await Send.NoContentAsync(ct);
    }
}