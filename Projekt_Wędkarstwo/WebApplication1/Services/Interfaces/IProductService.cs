using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();
        Task<ProductResponseDto?> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductResponseDto>> GetProductsByCategoryAsync(string category);
        Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto); 
    }
}
