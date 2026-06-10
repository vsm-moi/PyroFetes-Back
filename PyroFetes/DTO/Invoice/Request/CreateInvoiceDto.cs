namespace PyroFetes.DTO.Invoice.Request;

public class CreateInvoiceDto
{
    public int QuotationId { get; set; }
    public List<CreateProductInvoice>? Products { get; set; }
}