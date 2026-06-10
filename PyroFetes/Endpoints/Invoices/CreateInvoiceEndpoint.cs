using FastEndpoints;
using PyroFetes.DTO.Invoice.Request;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Products;

namespace PyroFetes.Endpoints.Invoices;

public class CreateInvoiceEndpoint(InvoicesRepository invoicesRepository,
    ProductsRepository productsRepository,
    InvoiceProductsRepository invoiceProductsRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreateInvoiceDto>
{
    public override void Configure()
    {
        Post("/invoices/quotation/{@QuotationId}", x => new {x.QuotationId});
        Roles("Admin","Employe");
    }

    public override async Task HandleAsync(CreateInvoiceDto req, CancellationToken ct)
    {
        Invoice invoice = mapper.Map<Invoice>(req);
        invoice.InvoicesProducts = [];

        if (req.Products is not null)
        {
            foreach (CreateProductInvoice product in req.Products)
            {
                bool checkProduct = await productsRepository.AnyAsync(new GetProductByIdSpec(product.ProductId), ct);

                if (!checkProduct)
                {
                    await Send.NotFoundAsync(ct);
                    return;
                }
                
                InvoiceProduct? invoiceProduct = mapper.Map<InvoiceProduct>(product);
                invoice.InvoicesProducts.Add(invoiceProduct);
            }
        }
        await invoicesRepository.AddAsync(invoice, ct);
        
        await Send.NoContentAsync(ct);
    }
}