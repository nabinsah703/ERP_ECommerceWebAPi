namespace ECommerceApp.DTOs.ProductVariationDTOs
{
    public class ProductVariationCreateDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CompanyID { get; set; }
        public int CategoryID { get; set; }

        public List<ProductVariationDetailDto>? Details { get; set; }
    }
}
