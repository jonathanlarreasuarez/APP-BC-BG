using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProducts.Domain.Entities;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


namespace ApiProducts.Infrastructure.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }


        public DbSet<User> Users { get; set; }  // DbSet para la tabla Users

        public DbSet<ProductConfig> ProductConfigs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductConfig>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductConfigs)
                .HasForeignKey(pc => pc.ProductId);
        }
    }
}
