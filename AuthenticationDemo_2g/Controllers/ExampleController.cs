﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationDemo_2g.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Public()
        {
            return View();
        }
        public IActionResult UsersOnly()
        {
            return View();
        }
        public IActionResult SpecificRoles()
        {
            return View();
        }
    }
}