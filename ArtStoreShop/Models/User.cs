﻿
namespace ArtStoreShop.Models
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public string firstname { get; set; }
        public string lastname { get; set; }
        public string adress { get; set; }
    }
}
