using Magic_Shop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Type = Magic_Shop.Models.Domain.Type;

namespace Magic_Shop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Variant> Variants { get; set; }
    }
}
