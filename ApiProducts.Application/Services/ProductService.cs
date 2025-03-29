using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProducts.Application.DTO;
using ApiProducts.Application.Interfaces;
using ApiProducts.Domain.Entities;
using ApiProducts.Domain.Interfaces;

namespace ApiProducts.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductConfigRepository _productConfigRepository;


        public ProductService(IProductRepository productRepository, IProductConfigRepository productConfigRepository)
        {
            _productRepository = productRepository;
            _productConfigRepository = productConfigRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _productRepository.GetAllAsync();

        public async Task<Product?> GetProductByIdAsync(int id) => await _productRepository.GetByIdAsync(id);

        //public async Task AddProductAsync(Product product) => await _productRepository.AddAsync(product);
        public async Task AddProductAsync(Product product) 
        {
            if (await _productRepository.ExistsBySkuAsync(product.SKU))
            {
                throw new InvalidOperationException("The SKU already exists. Please use a unique SKU.");
            }
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product) 
        {
            if (await _productRepository.ExistsBySkuAsync(product.SKU))
            {
                throw new InvalidOperationException("The SKU already exists. Please use a unique SKU.");
            }
            await _productRepository.UpdateAsync(product);
        } 

        public async Task DeleteProductAsync(int id) => await _productRepository.DeleteAsync(id);

        public async Task<List<ProductWithConfigInfoDto>> GetProductsWithConfigInfoAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = new List<ProductWithConfigInfoDto>();

            foreach (var product in products)
            {
                var lastNetValue = await _productConfigRepository.GetLatestNetPriceAsync(product.Id);
                var configCount = await _productConfigRepository.GetConfigCountAsync(product.Id);

                productDtos.Add(new ProductWithConfigInfoDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price != 0 ? product.Price : lastNetValue ?? 0,
                    SKU = product.SKU,
                    Description = product.Description,
                    lastNetValue = lastNetValue,
                    ConfigCount = configCount
                });
            }

            return productDtos;
        }
    }
}
