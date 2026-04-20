using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    [Table("tblOpeningQuantityImage", Schema = "Inv")]
    public class OpeningQuantityImage
    {
        [Key]
        public int ProductOpeningQuantityImageID { get; set; }

        // Foreign Key (Required)
        [Required]
        public int OpeningQuantityID { get; set; }

        [MaxLength(200)]
        public string FileName { get; set; }

        [MaxLength(50)]
        public string ImageType { get; set; }

        public DateTime? CreatedDate { get; set; }

        // Navigation Property
        [ForeignKey("OpeningQuantityID")]
        public virtual ProductOpeningQuantity OpeningQuantity { get; set; }
    }
}
