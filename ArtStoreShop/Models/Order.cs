
namespace ArtStoreShop.Models
{
    public class Order
    {
        public int id { get; set; }
        public double price { get; set; }
        public User user { get; set; }
        public string status { get; set; }
    }
}
