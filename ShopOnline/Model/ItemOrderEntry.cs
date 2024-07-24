using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Models
{
    [Table("ItemOrderEntry")]

    public class ItemOrderEntry
    {
        [Key]
        public int OEId { get; set; }

        public int ProductId { get; set; }

        public int EQuantity { get; set; }

        [Column(TypeName = "Money")]
        public decimal IntoMoney { set; get; }

        public OrderEntry OrderEntry { get; set; }

        public Product Product { get; set; }

    }
}
