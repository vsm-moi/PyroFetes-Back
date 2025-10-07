using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;

namespace PyroFetes;

public class PyroFetesDbContext : DbContext
{
    // Entities
    public DbSet<Availability> Availabilities { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Classification> Classifications { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Communication> Communications { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerContact> CustomerContacts { get; set; }
    public DbSet<CustomerType> CustomerTypes { get; set; }
    public DbSet<Deliverer> Deliverers { get; set; }
    public DbSet<DeliveryNote> DeliveryNotes { get; set; }
    public DbSet<Effect> Effects { get; set; }
    public DbSet<ExperienceLevel> ExperienceLevels { get; set; }
    public DbSet<HistoryOfApproval> HistoryOfApprovals { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Movement> Movements { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductDelivery> ProductDeliveries { get; set; }
    public DbSet<ProductEffect> ProductEffects { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<ProviderContact> ProviderContacts { get; set; }
    public DbSet<ProviderType> ProviderTypes { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
    public DbSet<Quotation> Quotations { get; set; }
    public DbSet<QuotationProduct> QuotationProducts { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Sound> Sounds { get; set; }
    public DbSet<SoundCategory> SoundCategories { get; set; }
    public DbSet<SoundTimecode> SoundTimecodes { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<StaffAvailability> StaffAvailabilities { get; set; }
    public DbSet<StaffContact> StaffContacts { get; set; }
    public DbSet<StaffHistoryOfApproval> StaffHistoryOfApprovals { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Truck> Trucks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<WarehouseProduct> WarehouseProducts { get; set; }

    // Database configuration
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString =
            "Server=romaric-thibault.fr;" + 
            "Database=PyroFetes;" + 
            "User Id=pyrofetes;" +
            "Password=Onto9-Cage-Afflicted;" +
            "TrustServerCertificate=true;";

        optionsBuilder.UseSqlServer(connectionString);
    }
    
    // Models customization
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relation SourceWarehouse
        modelBuilder.Entity<Movement>()
            .HasOne(m => m.SourceWarehouse)
            .WithMany(w => w.MovementsSource)
            .HasForeignKey(m => m.SourceWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relation DestinationWarehouse
        modelBuilder.Entity<Movement>()
            .HasOne(m => m.DestinationWarehouse)
            .WithMany(w => w.MovementsDestination)
            .HasForeignKey(m => m.DestinationWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}