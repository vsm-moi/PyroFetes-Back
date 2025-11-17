using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.Quotation.Response;
using PyroFetes.DTO.QuotationProduct.Response;

namespace PyroFetes.Endpoints.Quotation;

public class GetAllQuotationEndpoint(PyroFetesDbContext database) : EndpointWithoutRequest<List<GetQuotationDto>>
{
    public override void Configure()
    {
        Get("/api/quotations");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var quotations = await database.Quotations
            .Include(q => q.QuotationProducts!)
            .ThenInclude(qp => qp.Product)
            .Select(q => new GetQuotationDto
            {
                Id = q.Id,
                Message = q.Message,
                ConditionsSale = q.ConditionsSale,
                GetQuotationProductDto = q.QuotationProducts.Select(qp => new GetQuotationProductDto
                {
                    Quantity = qp.Quantity,
                    QuotationId = q.Id,
                    QuotationMessage = q.Message,
                    QuotationConditionsSale = q.ConditionsSale,
                    ProductId = qp.ProductId,
                    ProductReferences = qp.Product.Reference,
                    ProductName = qp.Product.Name,
                    ProductDuration = qp.Product.Duration,
                    ProductCaliber = qp.Product.Caliber,
                    ProductApprovalNumber = qp.Product.ApprovalNumber,
                    ProductWeight = qp.Product.Weight,
                    ProductNec = qp.Product.Nec,
                    ProductImage = qp.Product.Image,
                    ProductLink = qp.Product.Link,
                    ProductMinimalQuantity = qp.Product.MinimalQuantity,
                }).ToList()
            })
            .ToListAsync(ct);

        await Send.OkAsync(quotations, ct);
    }
}