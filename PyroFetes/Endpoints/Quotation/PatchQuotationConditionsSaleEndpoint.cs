using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.PurchaseOrder.Request;
using PyroFetes.DTO.PurchaseOrder.Response;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.DTO.Quotation.Request;
using PyroFetes.DTO.Quotation.Response;
using PyroFetes.DTO.QuotationProduct.Response;

namespace PyroFetes.Endpoints.Quotation;

public class PatchQuotationConditionsSaleEndpoint(PyroFetesDbContext database) : Endpoint<PatchQuotationConditionsSaleDto, GetQuotationDto>
{
    public override void Configure()
    {
        Patch("/api/quotations/{@Id}/ConditionsSale", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchQuotationConditionsSaleDto req, CancellationToken ct)
    {
        var quotation = await database.Quotations.SingleOrDefaultAsync(x => x.Id == req.Id, ct);
        if (quotation == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        quotation.ConditionsSale = req.ConditionsSale;
        await database.SaveChangesAsync(ct);

        GetQuotationDto responseDto = new()
        {
            Id = quotation.Id,
            Message = quotation.Message,
            ConditionsSale = quotation.ConditionsSale,
            GetQuotationProductDto = quotation.QuotationProducts.Select(qp => new GetQuotationProductDto
                {
                    Quantity = qp.Quantity,
                    QuotationId = quotation.Id,
                    QuotationMessage = quotation.Message,
                    QuotationConditionsSale = quotation.ConditionsSale,
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
        };
        await Send.OkAsync(responseDto, ct);
    }
}