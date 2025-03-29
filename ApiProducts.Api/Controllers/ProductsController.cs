using ApiProducts.Application.DTO;
using ApiProducts.Application.Services;
using ApiProducts.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiProducts.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll() => Ok(await _productService.GetAllProductsAsync());

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ProductRequestDto productDto)
        {
            // Validar el DTO
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Datos inválidos", errors = ModelState });
            }

            try
            {
                // Convertir el DTO a la entidad Product
                var product = new Product
                {
                    SKU = productDto.SKU,
                    Name = productDto.Name,
                    Price = productDto.Price
                };

                await _productService.AddProductAsync(product);
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            try
            {
                if (id != product.Id) return BadRequest();
                await _productService.UpdateProductAsync(product);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }

        [HttpGet("with-config-info")]
        public async Task<ActionResult<IEnumerable<ProductWithConfigInfoDto>>> GetProductsWithConfigInfo()
        {
            var products = await _productService.GetProductsWithConfigInfoAsync();

            if (products == null || !products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }

    }
}
