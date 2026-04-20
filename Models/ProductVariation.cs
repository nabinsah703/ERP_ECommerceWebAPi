namespace ECommerceApp.Models
{
    public class ProductVariation
    {
        public int ID { get; set; }
        //[Required(ErrorMessage = "Product Variation Name is required.")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int companyID { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<ProductVariationDetails> ProductVariationDetails { get; set; }
    }
}
