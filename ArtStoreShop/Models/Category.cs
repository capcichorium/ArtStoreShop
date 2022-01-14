using System.ComponentModel.DataAnnotations;

namespace ArtStoreShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Desc { get; set; }
    }
}
