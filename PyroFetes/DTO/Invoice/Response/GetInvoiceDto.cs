namespace PyroFetes.DTO.Invoice.Response;

public class GetInvoiceDto
{
    public int Id { get; set; }
    public int QuotationId { get; set; }
    public string? QuotationMessage { get; set; }
    public string? QuotationConditionsSale { get; set; }
    public string? QuotationCustomerId { get; set; }
    public string? CustomerName { get; set; }
}