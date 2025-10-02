using API.Class;

namespace API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int References { get; set; }
        public string Name { get; set; }
        public decimal Duration {get; set;} 
        public decimal Caliber { get; set; }
        public int ApprovalNumber { get; set; }
        public decimal Weight { get; set; }
        public decimal Nec { get; set; }
        public decimal SellingPrice { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }

        // Relations
        public int ClassificationId { get; set; }
        public Classification Classification { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public List<Brand> Brands { get; set; }
        
        public List<Movement> Movements { get; set; }
        
    }
}