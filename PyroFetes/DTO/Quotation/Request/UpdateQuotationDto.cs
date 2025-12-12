namespace PyroFetes.DTO.Quotation.Request;

public class UpdateQuotationDto
{
    public int Id { get; set; }
    public string? Message { get; set; }
    public string? ConditionsSale { get; set; }
}