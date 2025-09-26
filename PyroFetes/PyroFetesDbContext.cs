using Microsoft.EntityFrameworkCore;

namespace PyroFetes;

public class PyroFetesDbContext : DbContext
{
    // Entities
    
    
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
    }
}