using ApiProducts.Application.Interfaces;
using ApiProducts.Application.Services;
using ApiProducts.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiProducts.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductConfigController : ControllerBase
    {
        private readonly ProductConfigService _productConfigtService;

        public ProductConfigController(ProductConfigService productConfigService)
        {
            _productConfigtService = productConfigService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll() => Ok(await _productConfigtService.GetAllProductsAsync());

        [HttpGet("by-product/{productId}")]
        [Authorize]
        public async Task<ActionResult<List<ProductConfig>>> GetByProductIdAsync(int productId)
        {
            var configs = await _productConfigtService.GetByProductIdAsync(productId);
            if (configs == null || configs.Count == 0)
                return NotFound("No se encontraron configuraciones para este producto.");

            return Ok(configs);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productConfigtService.GetProductByIdAsync(id);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ProductConfig productConfig)
        {
            await _productConfigtService.AddProductAsync(productConfig);
            return CreatedAtAction(nameof(Get), new { id = productConfig.Id }, productConfig);
            //return Ok(productConfig);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] ProductConfig productConfig)
        {
            if (id != productConfig.Id) return BadRequest();
            await _productConfigtService.UpdateProductAsync(productConfig);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _productConfigtService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
