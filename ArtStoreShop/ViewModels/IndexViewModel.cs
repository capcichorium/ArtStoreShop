using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtStoreShop.Models;

namespace ArtStoreShop.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
