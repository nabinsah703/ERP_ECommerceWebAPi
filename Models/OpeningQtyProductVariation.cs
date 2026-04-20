using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    [Table("tblOpeningQtyProductVariation", Schema = "Inv")]
    public class OpeningQtyProductVariation
    {
        [Key]
        public int OpeningQtyProductVariationID { get; set; }

        // Foreign Keys
        public int? OpeningQtyID { get; set; }

        public int? ProductVariationDetailsID { get; set; }

        // Navigation Properties
        [ForeignKey("OpeningQtyID")]
        public virtual ProductOpeningQuantity OpeningQuantity { get; set; }

        [ForeignKey("ProductVariationDetailsID")]
        public virtual ProductVariationDetails ProductVariationDetails { get; set; }

    }
}
