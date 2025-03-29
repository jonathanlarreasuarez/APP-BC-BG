using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProducts.Domain.Entities;

namespace ApiProducts.Application.Interfaces
{
    public interface IProductConfigService
    {
        Task<IEnumerable<ProductConfig>> GetAllProductsAsync();

        Task<ProductConfig?> GetProductByIdAsync(int id);

        Task AddProductAsync(ProductConfig product);

        Task UpdateProductAsync(ProductConfig product);

        Task DeleteProductAsync(int id);

        //List<ProductConfig> GetByProductIdAsync(int productId);
        Task<List<ProductConfig>> GetByProductIdAsync(int productId);
    }
}
