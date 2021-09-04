using ArtStoreShop.Models;
using Microsoft.AspNetCore.Mvc;
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
        
        public IActionResult Index()
        {
            return View();
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
    }
}
