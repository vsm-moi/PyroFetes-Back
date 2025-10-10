using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(20)] public string? Reference { get; set; }
        [Required, MaxLength(100)] public string? Name { get; set; }
        [Required] public decimal Duration {get; set;} 
        [Required] public decimal Caliber { get; set; }
        [Required] public int ApprovalNumber { get; set; }
        [Required] public decimal Weight { get; set; }
        [Required] public decimal Nec { get; set; }
        [Required] public string? Image { get; set; }
        [Required, MaxLength(200)] public string? Link { get; set; }
        [Required] public int MinimalQuantity { get; set; }

        // Relations
        [Required] public int ClassificationId { get; set; }
        public Classification? Classification { get; set; }

        [Required] public int ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        
        [Required] public int MovementId {get; set;}
        public Movement? Movement {get; set;}

        public List<ProductDelivery>? ProductDeliveries { get; set; }
        public List<Brand>? Brands { get; set; }
        public List<ProductEffect>? ProductEffects { get; set; }
        public List<ProductColor>? ProductColors { get; set; }
        public List<PurchaseProduct>? PurchaseProducts { get; set; }
        public List<Price>? Prices { get; set; }
        public List<QuotationProduct>? QuotationProducts { get; set; }
        public List<WarehouseProduct>? WarehouseProducts { get; set; }
        public List<ProductTimecode>? ProductTimecodes { get; set; }
        
        
    }
}