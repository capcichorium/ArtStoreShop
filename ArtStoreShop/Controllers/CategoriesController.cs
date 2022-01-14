using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArtStoreShop.Models;

namespace ArtStoreShop.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationContext db;

        public CategoriesController(ApplicationContext context)
        {
            db = context;
        }
        
        public async Task<IActionResult> Index()
        {
            
            var categories = db.Categories;
            var SortCategories = from u in categories
                                 orderby u.CategoryName
                                 select u;
            return View(SortCategories);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
