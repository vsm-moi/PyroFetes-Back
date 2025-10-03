using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }
        [Required] public int References { get; set; }
        [Required, MaxLength(100)] public string? Name { get; set; }
        [Required] public decimal Duration {get; set;} 
        [Required] public decimal Caliber { get; set; }
        [Required] public int ApprovalNumber { get; set; }
        [Required] public decimal Weight { get; set; }
        [Required] public decimal Nec { get; set; }
        [Required] public decimal SellingPrice { get; set; }
        [Required] public string? Image { get; set; }
        [Required] public string? Link { get; set; }
        [Required] public int MinimalQuantity { get; set; }

        // Relations
        [Required] public int ClassificationId { get; set; }
        [Required] public Classification? Classification { get; set; }

        [Required] public int ProductCategoryId { get; set; }
        [Required] public ProductCategory? ProductCategory { get; set; }

        [Required] public List<Brand>? Brands { get; set; }
        
        [Required] public List<Movement>? Movements { get; set; }
        
    }
}