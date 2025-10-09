namespace PyroFetes.DTO.Product.Response;

public class GetProductDto
{
    public int Id { get; set; }
    public int References { get; set; }
    public string? Name { get; set; }
    public decimal Duration {get; set;} 
    public decimal Caliber { get; set; }
    public int ApprovalNumber { get; set; }
    public decimal Weight { get; set; }
    public decimal Nec { get; set; }
    public string? Image { get; set; }
    public string? Link { get; set; }
    public int MinimalQuantity { get; set; }
}