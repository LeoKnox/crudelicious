using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using crudelicious.Models;
using System.Linq;

namespace crudelicious.Controllers
{
    public class HomeController : Controller
    {
        private crudeliciousContext dbContext;
        public HomeController(crudeliciousContext context)
        {
            dbContext =context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("addDish")]
        [HttpGet]
        public IActionResult newDish()
        {
            return View();
        }

        [Route("Single")]
        [HttpGet]
        public IActionResult showOne()
        {
            return View();
        }

        [Route("Edit")]
        [HttpGet]
        public IActionResult editDish()
        {
            return View();
        }
    }
}
