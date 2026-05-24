namespace PyroFetes.DTO.Product.Request;

public class UpdateProductDto
{
    public int Id { get; set; }
    public string? References { get; set; }
    public string? Name { get; set; }
    public decimal Duration { get; set; }
    public int Caliber { get; set; }
    public string? ApprovalNumber { get; set; }
    public decimal Weight { get; set; }
    public decimal Nec { get; set; }
    public string? Image { get; set; }
    public string? Link { get; set; }
    public int MinimalQuantity { get; set; }
}