﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ngay14_7.Controllers
{
    public class AccountController : Controller
    {   
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    }

}
