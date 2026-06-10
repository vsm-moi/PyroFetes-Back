using PyroFetes.DTO.Invoice.Response;
using PyroFetes.DTO.QuotationProduct.Response;

namespace PyroFetes.DTO.Quotation.Response;

public class GetQuotationDto
{
    public int Id { get; set; }
    public string? Message { get; set; }
    public string? ConditionsSale { get; set; }
    
    public int TotalInvoices { get; set; }
    public List<GetQuotationProductDto>? Products { get; set; }
    public List<GetInvoiceDto>? Invoices { get; set; }
}