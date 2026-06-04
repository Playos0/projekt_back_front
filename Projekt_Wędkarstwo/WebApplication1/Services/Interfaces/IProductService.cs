using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();

        Task<IEnumerable<ProductResponseDto?>> GetProductsByCategoryAsync(string category);

        Task<ProductResponseDto?> GetProductByIdAsync(int id);
        Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto); 
    }
}
