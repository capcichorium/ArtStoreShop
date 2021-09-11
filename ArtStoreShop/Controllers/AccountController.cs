using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArtStoreShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ArtStoreShop.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationContext _context;
        public AccountController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { email = model.Email, password = model.Password };
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.name == "user");
                    if (userRole != null)
                        user.role = userRole;

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    if (user.role.name == "admin")
                        return RedirectToAction("Login", "Account");
                    else 
                        return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.role)
                    .FirstOrDefaultAsync(u => u.email == model.Email && u.password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    if (user.role.name == "admin")
                        return RedirectToAction("Login", "Account");
                    else
                        return RedirectToAction("Login", "Account");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");

            }
            return View(model);
        }
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.role?.name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
       
    }
}
