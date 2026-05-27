using PyroFetes.DTO.QuotationProduct.Request;

namespace PyroFetes.DTO.Quotation.Request;

public class CreateQuotationDto
{
    public string? Message { get; set; }
    public string? ConditionsSale { get; set; }
    public int CustomerId { get; set; }
    public int SupplierId { get; set; }
    public List<CreateProductQuotationDto>? Products { get; set; }
}