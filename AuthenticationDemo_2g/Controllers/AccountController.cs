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
        public IActionResult Login(string ReturnUrl = null)    // TODO: Hier nog parameter toevoegen voor ReturnUrl
        {
            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (!ModelState.IsValid || !user.Name.ToLowerInvariant().Contains("rt"))
            {
                return View(user);
            }
            else
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Name)
                };
                claims.Add(new Claim(ClaimTypes.Role, "gebruiker"));
                if (user.Name.ToLowerInvariant().Equals("martijn"))
                {
                    claims.Add(new Claim(ClaimTypes.Role, "alleskunner"));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "simpele ziel"));
                }
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                string returnUrl = "/";
                if (TempData["ReturnUrl"] != null)
                    returnUrl = TempData["ReturnUrl"].ToString();
                return LocalRedirect(returnUrl);
            }

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}