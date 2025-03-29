using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProducts.Domain.Entities;
using ApiProducts.Domain.Interfaces;
using ApiProducts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiProducts.Infrastructure.Repositories
{
    public class ProductConfigRepository : IProductConfigRepository
    {
        private readonly ApiDbContext _context;

        public ProductConfigRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductConfig>> GetAllAsync() => await _context.ProductConfigs.ToListAsync();
        public async Task<ProductConfig?> GetByIdAsync(int id) => await _context.ProductConfigs.FindAsync(id);
        public async Task AddAsync(ProductConfig product) { _context.ProductConfigs.Add(product); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(ProductConfig product) { _context.ProductConfigs.Update(product); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id) { var product = await _context.ProductConfigs.FindAsync(id); if (product != null) { _context.ProductConfigs.Remove(product); await _context.SaveChangesAsync(); } }

        public async Task<List<ProductConfig>> GetByProductIdAsync(int productId)
        {
            return await _context.ProductConfigs
                .Where(pc => pc.ProductId == productId)
                .OrderByDescending(pc => pc.BatchDate) // Opcional: Ordenar por fecha de lote
                .ToListAsync();
        }

        public async Task<DateTime?> GetLatestBatchDateAsync(int productId)
        {
            return await _context.ProductConfigs
                .Where(pc => pc.ProductId == productId)
                .OrderByDescending(pc => pc.BatchDate)
                .Select(pc => (DateTime?)pc.BatchDate)
                .FirstOrDefaultAsync();
        }

        public async Task<decimal?> GetLatestNetPriceAsync(int productId)
        {
            return await _context.ProductConfigs
                .Where(pc => pc.ProductId == productId)
                .OrderByDescending(pc => pc.BatchDate)
                .Select(pc => (decimal?)pc.NetPrice)
                .FirstOrDefaultAsync();
        }


        public async Task<int> GetConfigCountAsync(int productId)
        {
            return await _context.ProductConfigs
                .CountAsync(pc => pc.ProductId == productId);
        }
    }
}
