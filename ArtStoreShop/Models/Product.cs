
namespace ArtStoreShop.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public double price { get; set; }
        public bool available { get; set; }
        public int categoryId { get; set; }
        public bool isFavorite { get; set; }
        public virtual Category category { get; set; }
    }
}
