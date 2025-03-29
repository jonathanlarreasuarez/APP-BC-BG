using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProducts.Domain.Entities;

namespace ApiProducts.Domain.Interfaces
{
    public interface IProductConfigRepository
    {
        Task<IEnumerable<ProductConfig>> GetAllAsync();
        Task<ProductConfig?> GetByIdAsync(int id);
        Task AddAsync(ProductConfig product);
        Task UpdateAsync(ProductConfig product);
        Task DeleteAsync(int id);
        Task<List<ProductConfig>> GetByProductIdAsync(int productId);
        Task<DateTime?> GetLatestBatchDateAsync(int productId);

        Task<decimal?> GetLatestNetPriceAsync(int productId);
        Task<int> GetConfigCountAsync(int productId);
    }
}
