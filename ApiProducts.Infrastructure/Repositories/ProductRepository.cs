using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProducts.Domain.Entities;
using ApiProducts.Domain.Interfaces;
using ApiProducts.Infrastructure.Data;
using ApiProducts.Application.DTO;
using Microsoft.EntityFrameworkCore;


namespace ApiProducts.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext _context;
                                                                                                                                    
        public ProductRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();
        public async Task<Product?> GetByIdAsync(int id) => await _context.Products.FindAsync(id);
        public async Task AddAsync(Product product) { _context.Products.Add(product); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Product product) { _context.Products.Update(product); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id) { var product = await _context.Products.FindAsync(id); if (product != null) { _context.Products.Remove(product); await _context.SaveChangesAsync(); } }

        public async Task<bool> ExistsBySkuAsync(string sku)
        {
            return await _context.Products.AnyAsync(p => p.SKU == sku);
        }

    }
}
