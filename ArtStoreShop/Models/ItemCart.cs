using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtStoreShop.Models
{
    public class ItemCart
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
    }
}
