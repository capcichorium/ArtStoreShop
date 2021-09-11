using ArtStoreShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ArtStoreShop.Controllers
{
    
    public class HomeController : Controller
    {
        private ApplicationContext db;
        
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Categories.ToListAsync());
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

        public IActionResult About()
        {
            return View();
        }
        
      
        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult PersonalAccount()
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
    }
}
