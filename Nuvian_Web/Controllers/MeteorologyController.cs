﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nuvian_Web.Controllers
{
    public class MeteorologyController : Controller
    {
        public IActionResult Iframe()
        {
            return View();
        }
    }
}
