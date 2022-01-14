using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtStoreShop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Status { get; set; }
    }
}
