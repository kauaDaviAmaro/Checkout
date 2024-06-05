using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Database;

public partial class CheckoutDbContext : DbContext
{
    // User
    public DbSet<User> Users { get; set; }

    // Product
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }

    // Message
    public DbSet<Messages> Messages { get; set; }

    // Checkout
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }


    public CheckoutDbContext()
    {
        Database.EnsureCreated();
        Database.Migrate();
    }

    public CheckoutDbContext(DbContextOptions<CheckoutDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;userid=root;database=Checkout", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Payment>()
            .Property(p => p.Details)
            .HasConversion(
                v => JsonSerializer.Serialize(
                    v, 
                    new JsonSerializerOptions { WriteIndented = true }
                ),
                v => JsonSerializer.Deserialize<Dictionary<string, string>>(
                    v, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                ) ?? new Dictionary<string, string>()
            );

        base.OnModelCreating(modelBuilder);
    }
}
