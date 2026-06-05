using WebApplication1.Data;
using WebApplication1.Models.DTOs;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{
    public class ProductService : IProductService
    {
        public readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
        {
            return await _context.Products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Stock = p.Stock
            }).ToListAsync();
        }

        public async Task<IEnumerable<ProductResponseDto?>> GetProductsByCategoryAsync(string category)
        {
            return await _context.Products.Where(p => p.Category == category).Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Stock = p.Stock
            }).ToListAsync();
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            return await _context.Products.Where(p => p.Id == id).Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Stock = p.Stock
            }).FirstOrDefaultAsync();

        }

        public async Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto)
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
            await _context.SaveChangesAsync();

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public async Task<ProductResponseDto?> UpdateProductAsync(UpdateProductDto dto, int id)
        {
            var productToUpdate = await _context.Products.FindAsync(id);

            if (productToUpdate == null)
            {
                return null;
            }

            productToUpdate.Name = dto.Name;
            productToUpdate.Description = dto.Description;
            productToUpdate.Category = dto.Category;
            productToUpdate.ImageUrl = dto.ImageUrl;
            productToUpdate.Price = dto.Price;
            productToUpdate.Stock = dto.Stock;

            await _context.SaveChangesAsync();

            return new ProductResponseDto
            {
                Id = productToUpdate.Id,
                Name = productToUpdate.Name,
                Description = productToUpdate.Description,
                Category = productToUpdate.Category,
                ImageUrl = productToUpdate.ImageUrl,
                Price = productToUpdate.Price,
                Stock = productToUpdate.Stock
            };


        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var productToDelete = await _context.Products.FindAsync(id);
            if (productToDelete == null)
            {
                return false;
            }
            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
