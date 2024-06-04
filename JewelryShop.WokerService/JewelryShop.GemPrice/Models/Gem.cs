using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryShop.GemPrice.Models
{
    [Table("Gem")]
    public class Gem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GemId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public double Carat { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Clarity { get; set; }

        [StringLength(50)]
        public string Cut { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
