using WebApplication1.Data;
using WebApplication1.Models.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ProductService
    {
        public readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = _context.Products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Stock = p.Stock
            });
            return Task.FromResult(products.AsEnumerable());
        }

        Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Stock = p.Stock
            }).FirstOrDefault();

            return Task.FromResult(product);
        }

        Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Category = dto.Category,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                Stock = dto.Stock
            };

            _context.Products.Add(product);
            _context.SaveChangesAsync();

            return Task.FromResult(new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Stock = product.Stock
            });
        }
    }
}
