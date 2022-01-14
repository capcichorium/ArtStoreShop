using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtStoreShop.Models;
using Microsoft.EntityFrameworkCore;
using ArtStoreShop.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ArtStoreShop.Controllers
{
    public class ProductsController : Controller
    {
        ApplicationContext db;
        IEnumerable<Category> categories;
        IWebHostEnvironment _appEnvironment;
        public ProductsController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Products.ToListAsync());

        }
        public IActionResult Create()
        {;
            //return View(db.Categories);
            categories = db.Categories;
            ViewBag.categories = new SelectList(categories, "Id", "CategoryName","Desc");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product prod, int categoryId,IFormFile uploadedFile)
        {
            Product product = new Product { Name = prod.Name, CategoryId = categoryId, Avatar = "/img/" + uploadedFile.FileName };
           
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/img/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                db.Files.Add(file);
                db.SaveChanges();
            }



            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
