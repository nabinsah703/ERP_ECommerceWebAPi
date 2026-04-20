using ECommerceApp.DTOs.ProductVariationDTOs;
using ECommerceApp.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationService _service;

        public ProductVariationController(IProductVariationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVariationCreateDto dto)
        {
            var id = await _service.CreateVariationAsync(dto);
            return Ok(new { VariationId = id });
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetAll(int companyId)
        {
            var data = await _service.GetAllAsync(companyId);
            return Ok(data);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }
    }
}
