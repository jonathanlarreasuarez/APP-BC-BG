using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProducts.Application.Interfaces;
using ApiProducts.Domain.Entities;
using ApiProducts.Domain.Interfaces;

namespace ApiProducts.Application.Services
{
    public class ProductConfigService : IProductConfigService
    {

        private readonly IProductConfigRepository _productConfigRepository;

        public ProductConfigService(IProductConfigRepository productConfigRepository)
        {
            _productConfigRepository = productConfigRepository;
        }

        public async Task AddProductAsync(ProductConfig product)
        {
            await _productConfigRepository.AddAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productConfigRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductConfig>> GetAllProductsAsync()
        {
            return await _productConfigRepository.GetAllAsync();
        }

        public async Task<ProductConfig?> GetProductByIdAsync(int id)
        {
            return await _productConfigRepository.GetByIdAsync(id);
        }

        public async Task UpdateProductAsync(ProductConfig product)
        {
            await _productConfigRepository.UpdateAsync(product);
        }

        public async Task<List<ProductConfig>> GetByProductIdAsync(int productId)
        {
            return await _productConfigRepository.GetByProductIdAsync(productId);
        }
    }
}
