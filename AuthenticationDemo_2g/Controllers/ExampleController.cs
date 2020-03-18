using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationDemo_2g.Controllers
{
    [Authorize]
    public class ExampleController : Controller
    {
        [AllowAnonymous]
        public IActionResult Public()
        {
            return View();
        }
        public IActionResult UsersOnly()
        {
            return View();
        }
        [Authorize(Roles = "alleskunner")]
        public IActionResult SpecificRoles()
        {
            return View();
        }
    }
}