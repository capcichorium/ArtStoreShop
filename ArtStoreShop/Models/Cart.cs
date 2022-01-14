using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtStoreShop.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int NumItems { get; set; }
        public decimal Price { get; set; }
        public List<ItemCart> listItems { get; set; }
    }
}
