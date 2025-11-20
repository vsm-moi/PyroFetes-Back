namespace PyroFetes.DTO.Supplier.Request;

public class CreateSupplierDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? ZipCode { get; set; }
    public string? City { get; set; }
    public int DeliveryDelay { get; set; }
}