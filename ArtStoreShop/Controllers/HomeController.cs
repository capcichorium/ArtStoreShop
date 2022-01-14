using ArtStoreShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ArtStoreShop.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace ArtStoreShop.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationContext db;
        IEnumerable<Product> products;
        IEnumerable<Category> categories;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            products = db.Products;
            categories  = from u in db.Categories
                                 orderby u.CategoryName
                                 select u;
            var ivm = new IndexViewModel { Categories = categories, Products = products };
            return View(ivm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            var prod = db.Products.Where(i => i.CategoryId == id);
            categories = from u in db.Categories
                         orderby u.CategoryName
                         select u;
            var ivm = new IndexViewModel { Categories = categories, Products = prod };
            return View(ivm);
        }
        public IActionResult About()
        {
            return View();
        }
        
        public IActionResult Info()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var prod = db.Products.FirstOrDefault(i => i.Id == id);
            var cart = new Cart();
            if (prod != null)
            {
                var item = new ItemCart() {ProductId = prod.Id, Avatar = prod.Avatar, Name = prod.Name, Price = prod.Price};
                cart.listItems.Add(item);
                item.CartId = cart.CartId;
                db.Carts.Add(cart);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
