using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtStoreShop.Models
{
    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<User> users { get; set; }
        public Role()
        {
            users = new List<User>();
        }
    }
}
