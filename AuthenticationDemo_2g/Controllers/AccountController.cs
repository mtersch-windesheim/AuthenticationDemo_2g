using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthenticationDemo_2g.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationDemo_2g.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()    // TODO: Hier nog parameter toevoegen voor ReturnUrl
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Jantje"),
                new Claim("FullName", "Jan Klaassen"),
                new Claim(ClaimTypes.Role, "Administrator")
            };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }
    }
}