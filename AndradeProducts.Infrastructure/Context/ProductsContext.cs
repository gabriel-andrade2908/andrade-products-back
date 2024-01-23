using AndradeProducts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AndradeProducts.Infrastructure.Context
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Products;Trusted_Connection=True");
        }
    }
}
