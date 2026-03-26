using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;
using ServiceProvider = PyroFetes.Models.ServiceProvider;

namespace PyroFetes;

public class PyroFetesDbContext : DbContext
{
    // Entities
    public DbSet<Availability> Availabilities { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Classification> Classifications { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Communication> Communications { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactServiceProvider> ContactServiceProviders { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerType> CustomerTypes { get; set; }
    public DbSet<Deliverer> Deliverers { get; set; }
    public DbSet<DeliveryNote> DeliveryNotes { get; set; }
    public DbSet<Effect> Effects { get; set; }
    public DbSet<ExperienceLevel> ExperienceLevels { get; set; }
    public DbSet<HistoryOfApproval> HistoryOfApprovals { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<MaterialWarehouse> MaterialWarehouses { get; set; }
    public DbSet<Movement> Movements { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductDelivery> ProductDeliveries { get; set; }
    public DbSet<ProductEffect> ProductEffects { get; set; }
    public DbSet<ProductTimecode> ProductTimecodes { get; set; }
    public DbSet<ProviderContact> ProviderContacts { get; set; }
    public DbSet<ProviderType> ProviderTypes { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
    public DbSet<Quotation> Quotations { get; set; }
    public DbSet<QuotationProduct> QuotationProducts { get; set; }
    public DbSet<ServiceProvider> ServiceProviders { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<ShowMaterial> ShowMaterials { get; set; }
    public DbSet<ShowServiceProvider> ShowServiceProviders { get; set; }
    public DbSet<ShowStaff> ShowStaffs { get; set; }
    public DbSet<ShowTruck> ShowTrucks { get; set; }
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
            "Server=localhost,1433;" +
            "Database=pyrofetes-db;" +
            "User Id=sa;" +
            "Password=AdminMotDePasse!;" +
            "TrustServerCertificate=true;";

        optionsBuilder.UseSqlServer(connectionString);


    }
    
    // Models customization
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movement>()
            .HasOne(m => m.SourceWarehouse)
            .WithMany(w => w.MovementsSource)
            .HasForeignKey(m => m.SourceWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Movement>()
            .HasOne(m => m.DestinationWarehouse)
            .WithMany(w => w.MovementsDestination)
            .HasForeignKey(m => m.DestinationWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<MaterialWarehouse>()
            .HasOne(mw => mw.Material)
            .WithMany(m => m.MaterialWarehouses)
            .HasForeignKey(mw => mw.MaterialId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MaterialWarehouse>()
            .HasOne(mw => mw.Warehouse)
            .WithMany(w => w.MaterialWarehouses)
            .HasForeignKey(mw => mw.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}