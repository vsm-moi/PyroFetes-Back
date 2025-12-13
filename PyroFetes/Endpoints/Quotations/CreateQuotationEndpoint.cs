using FastEndpoints;
using PyroFetes.DTO.Quotation.Request;
using PyroFetes.DTO.Quotation.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Quotations;

public class CreateQuotationEndpoint(
    QuotationsRepository quotationsRepository,
    ProductsRepository productsRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreateQuotationDto, GetQuotationDto>
{
    public override void Configure()
    {
        Post("/quotations");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateQuotationDto req, CancellationToken ct)
    {
        Quotation quotation = new Quotation
        {
            Message = req.Message,
            ConditionsSale = req.ConditionsSale ?? "Conditions non précisées",
            CustomerId = 1, // A changer
            QuotationProducts = new List<QuotationProduct>()
        };

        foreach (var line in req.Products)
        {
            var product = await productsRepository.GetByIdAsync(line.ProductId, ct);
            if (product == null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }

            quotation.QuotationProducts.Add(new QuotationProduct
            {
                ProductId = product.Id,
                Quantity = line.Quantity,
            });
        }

        await quotationsRepository.AddAsync(quotation, ct);

        await Send.OkAsync(mapper.Map<GetQuotationDto>(quotation), ct);
    }
}