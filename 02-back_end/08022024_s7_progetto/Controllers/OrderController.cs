﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace _08022024_s7_progetto.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

