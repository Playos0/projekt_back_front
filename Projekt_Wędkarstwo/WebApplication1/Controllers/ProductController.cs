using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {


        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts([FromServices] IProductService productService)
        {
            var products = await productService.GetAllProductsAsync();

            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }
            return Ok(products);
        }

        [HttpGet("GetProductsByCategory/{category}")]
        public async Task<IActionResult> GetProductsByCategory(string category, [FromServices] IProductService productService)
        {
            var products = await productService.GetProductsByCategoryAsync(category);

            if (products == null || !products.Any())
            {
                return NotFound($"No products found in category '{category}'.");
            }

            return Ok(products);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id, [FromServices] IProductService productService)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound($"Product with ID {id} not found");
            }

            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto, [FromServices] IProductService productService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProduct = await productService.CreateProductAsync(dto);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto dto, [FromServices] IProductService productService)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await productService.UpdateProductAsync(dto, id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while updating product {ex.Message}");

            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id, [FromServices] IProductService productService)
        {
            try
            {
                var result = await productService.DeleteProductAsync(id);

                if (!result)
                    return NotFound($"Product with ID {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while deleting product: {ex.Message}");
            }

        }
    }
}
