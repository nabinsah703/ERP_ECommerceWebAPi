namespace ECommerceApp.DTOs.ProductVariationDTOs
{
    public class ProductVariationResponseDto
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CompanyID { get; set; }

        public List<ProductVariationDetailDto> Details { get; set; }
    }
}
