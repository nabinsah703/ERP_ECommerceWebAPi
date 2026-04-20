using ECommerceApp.DTOs.ProductVariationDTOs;

namespace ECommerceApp.Interface
{
    public interface IProductVariationService
    {
        Task<int> CreateVariationAsync(ProductVariationCreateDto dto);
        Task<List<ProductVariationResponseDto>> GetAllAsync(int companyId);
        Task<ProductVariationResponseDto?> GetByIdAsync(int id);
    }
}
