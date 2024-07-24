using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopBanHang.Models
{

    [Table("Account")]
    public class Account
    {
        [Key]
        public int AccountId { set; get; }

        [Required]
        [StringLength(50)]
        public string UserName { set; get; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Password { set; get; }

        [Required]
        [StringLength(20)]
        public string Position { set; get; }

        [Required]
        [StringLength(50)]
        public string FullName { set; get; } = string.Empty;

        [StringLength(10)]
        public string Sex { set; get; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string Address { set; get; } = string.Empty;

        [Phone]
        [Required]
        [StringLength(11)]
        public int PhoneNumber { set; get; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { set; get; } = string.Empty;

        [StringLength(200)]
        public string Picture { set; get; } = string.Empty;
    }
}
