using Microsoft.Identity.Client;

namespace ECommerceApp.Models
{
    public class ProductVariationDetails
    {
        public int ProductVariationDetailsID { get; set; }
        public string? Name { get; set; }
        public int? ProductVariationID { get; set; }
        public ProductVariation ProductVariation { get; set; }
        public string? Description { get; set; }

    }
}
