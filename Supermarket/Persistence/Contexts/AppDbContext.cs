using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Models;

namespace Supermarket.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.CategoryId);
            builder.Entity<Category>().Property(p => p.CategoryId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.CategoryName).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            // Two example categories to test the endpoint
            // Setting the id property, because we use in-memory db provider
            builder.Entity<Category>().HasData
            (
                new Category { CategoryId = 100, CategoryName = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
                new Category { CategoryId = 101, CategoryName = "Dairy" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.ProductId);
            builder.Entity<Product>().Property(p => p.ProductId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.ProductName).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

            builder.Entity<Product>().HasData
            (
                new Product
                {
                    ProductId = 100,
                    ProductName = "Apple",
                    QuantityInPackage = 1,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 100
                },
                new Product
                {
                    ProductId = 101,
                    ProductName = "Milk",
                    QuantityInPackage = 2,
                    UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    CategoryId = 101,
                }
            );
        }
    }
}