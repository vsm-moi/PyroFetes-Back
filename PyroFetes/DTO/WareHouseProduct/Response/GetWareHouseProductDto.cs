namespace PyroFetes.DTO.WareHouseProduct.Response;

public class GetWareHouseProductDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    
    public int WareHouseId { get; set; }
    public string? WareHouseName {get; set;}
    public int WareHouseMaxWeight {get; set;}
    public int WareHouseCurrent {get; set;}
    public int WareHouseMinWeight {get; set;}
    public string? WareHouseAddress { get; set; }
    public int WareHouseZipCode { get; set; }
    public string? WareHouseCity { get; set; }
    
    public int ProductId { get; set; }
    public int ProductReferences { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductDuration {get; set;} 
    public decimal ProductCaliber { get; set; }
    public int ProductApprovalNumber { get; set; }
    public decimal ProductWeight { get; set; }
    public decimal ProductNec { get; set; }
    public string? ProductImage { get; set; }
    public string? ProductLink { get; set; }
    public int ProductMinimalQuantity { get; set; }
}