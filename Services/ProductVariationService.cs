using ECommerceApp.Data;
using ECommerceApp.DTOs.ProductVariationDTOs;
using ECommerceApp.Interface;
using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Services
{
    public class ProductVariationService : IProductVariationService
    {
        private readonly ApplicationDbContext _context;

        public ProductVariationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateVariationAsync(ProductVariationCreateDto dto)
        {
            var variation = new ProductVariation
            {
                Name = dto.Name,
                Description = dto.Description,
                companyID = dto.CompanyID,
                CategoryID = dto.CategoryID,
                ProductVariationDetails = dto.Details?.Select(d => new ProductVariationDetails
                {
                    Name = d.Name,
                    Description = d.Description
                }).ToList()!
            };

            _context.ProductVariations.Add(variation);
            await _context.SaveChangesAsync();

            return variation.ID;
        }

        public async Task<List<ProductVariationResponseDto>> GetAllAsync(int companyId)
        {
            return await _context.ProductVariations
                .Where(x => x.companyID == companyId)
                .Select(x => new ProductVariationResponseDto
                {
                    ID = x.ID,
                    Name = x.Name,
                    Description = x.Description,
                    CompanyID = x.companyID,
                    

                    Details = x.ProductVariationDetails.Select(d => new ProductVariationDetailDto
                    {
                        Name = d.Name,
                        Description = d.Description
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<ProductVariationResponseDto?> GetByIdAsync(int id)
        {
            var data = await _context.ProductVariations
                .Include(x => x.ProductVariationDetails)
                .FirstOrDefaultAsync(x => x.ID == id);

            if (data == null) return null;

            return new ProductVariationResponseDto
            {
                ID = data.ID,
                Name = data.Name,
                Description = data.Description,
                CompanyID = data.companyID,
                Details = data.ProductVariationDetails.Select(d => new ProductVariationDetailDto
                {
                    Name = d.Name,
                    Description = d.Description
                }).ToList()
            };
        }
    }
}
