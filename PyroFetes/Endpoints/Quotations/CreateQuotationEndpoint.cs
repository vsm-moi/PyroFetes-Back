using FastEndpoints;
using PyroFetes.DTO.Quotation.Request;
using PyroFetes.DTO.QuotationProduct.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Products;
using PyroFetes.Specifications.QuotationProducts;

namespace PyroFetes.Endpoints.Quotations;

public class CreateQuotationEndpoint(
    QuotationsRepository quotationsRepository,
    QuotationProductsRepository quotationProductsRepository,
    ProductsRepository productsRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreateQuotationDto>
{
    public override void Configure()
    {
        Post("/quotations");
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(CreateQuotationDto req, CancellationToken ct)
    {
        Quotation quotation = mapper.Map<Quotation>(req);
        await quotationsRepository.AddAsync(quotation, ct);

        if (req.Products != null)
        {
            foreach (CreateProductQuotationDto line in req.Products)
            {
                Product? product = await productsRepository.SingleOrDefaultAsync(new GetProductByIdSpec(line.ProductId), ct);
                QuotationProduct? quotationProduct =
                    await quotationProductsRepository.SingleOrDefaultAsync(new GetQuotationProductByProductIdAndQuotationIdSpec(line.ProductId, quotation.Id), ct);

                if (product is null)
                {
                    await Send.NotFoundAsync(ct);
                    return;
                }

                if (quotationProduct is not null)
                {
                    await Send.StringAsync("Le produit est déjà dans le devis", 400, cancellation: ct);
                    return;
                }

                QuotationProduct? productOnQuotation = mapper.Map<QuotationProduct>(line);
                productOnQuotation.QuotationId = quotation.Id;

                await quotationProductsRepository.AddAsync(productOnQuotation, ct);
            }
        }
        
        await Send.NoContentAsync(ct);
    }
}