using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    [Table("tblOpeningQuantity", Schema = "Inv")]
    public class ProductOpeningQuantity
    {

        [Key]
        public int OpeningQuantityID { get; set; }

        // Foreign Key
        public int? ProductID { get; set; }

        public int? AccClassID { get; set; }

        // Quantity
        public double? PurchaseQty { get; set; }

        public DateTime? QuantityDate { get; set; }

        // Rates
        [Column(TypeName = "money")]
        public decimal? PurchaseRate { get; set; }

        [Column(TypeName = "money")]
        public decimal? SalesRate { get; set; }
        public ICollection<OpeningQuantityImage> Images { get; set; }
        // Navigation Property
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        public ICollection<OpeningQtyProductVariation> OpeningQtyProductVariations { get; set; }


    }
}
