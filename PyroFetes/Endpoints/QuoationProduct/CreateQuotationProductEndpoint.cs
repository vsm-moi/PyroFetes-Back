using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.PurchaseProduct.Request;
using PyroFetes.DTO.PurchaseProduct.Response;
using PyroFetes.DTO.QuotationProduct.Request;
using PyroFetes.DTO.QuotationProduct.Response;

namespace PyroFetes.Endpoints.QuoationProduct;

public class CreateQuotationProductEndpoint(PyroFetesDbContext database) : Endpoint<CreateQuotationProductDto, GetQuotationProductDto>
{
    public override void Configure()
    {
        Post("/api/quotationProduct");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateQuotationProductDto req, CancellationToken ct)
    {
        var product = await database.Products.FirstOrDefaultAsync(p => p.Id == req.ProductId, ct);
        if (product == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        var quotation = await database.Quotations.FirstOrDefaultAsync(q => q.Id == req.QuotationId, ct);
        
        if (quotation == null)
        {
            quotation = new Models.Quotation()
            {
                Message = req.QuotationMessage ?? "",
                ConditionsSale = req.QuotationConditionsSale,
            };
            database.Quotations.Add(quotation);
            await database.SaveChangesAsync(ct);
        }
        
        var quotationProduct = new Models.QuotationProduct()
        {
            ProductId = product.Id,
            QuotationId = quotation.Id,
            Quantity = req.Quantity
        };
        database.QuotationProducts.Add(quotationProduct);
        await database.SaveChangesAsync(ct);
        
        var responseDto = new GetQuotationProductDto()
        {
            ProductId = product.Id,
            ProductReferences = product.Reference,
            ProductName = product.Name,
            ProductDuration = product.Duration,
            ProductCaliber = product.Caliber,
            ProductApprovalNumber = product.ApprovalNumber,
            ProductWeight = product.Weight,
            ProductNec = product.Nec,
            ProductImage = product.Image,
            ProductLink = product.Link,
            ProductMinimalQuantity = product.MinimalQuantity,
            Quantity = quotationProduct.Quantity,
            QuotationMessage = quotation.Message,
            QuotationConditionsSale = quotation.ConditionsSale,
            QuotationId = quotation.Id,
        };

        await Send.OkAsync(responseDto, ct);
    }
}
