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
            dbContext = context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            List<MyModel> AllCruds = dbContext.mymodels.ToList();
            return View("Index", AllCruds);
        }

        [Route("addDish")]
        [HttpGet]
        public IActionResult newDish()
        {
            return View();
        }

        [Route("pushDish")]
        [HttpPost]
        public IActionResult createDish(MyModel newItem)
        {
            if (ModelState.IsValid) {
                dbContext.Add(newItem);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewDish");
            }
        }

        [Route("Single/{dishId}")]
        [HttpGet]
        public IActionResult showOne(Int32 dishId)
        {
            MyModel OneCurd = dbContext.mymodels.Where(mmod => mmod.MyModelId == dishId).FirstOrDefault();
            return View("Single", OneCurd);
        }

        [Route("Edit/{updateId}")]
        [HttpGet]
        public IActionResult editDish(Int32 updateId)
        {
            MyModel OneUpdate = dbContext.mymodels.Where(mmod => mmod.MyModelId == updateId).FirstOrDefault();
            return View("Edit", OneUpdate);
        }

        [Route("updateDish")]
        [HttpPost]
        public IActionResult upDish(MyModel uDish)
        {
            if (ModelState.IsValid) {
                MyModel RetDish = dbContext.mymodels.FirstOrDefault(uMod => uMod.MyModelId == uDish.MyModelId);
                RetDish.chefName = uDish.chefName;
                RetDish.dishName = uDish.dishName;
                RetDish.Calories = uDish.Calories;
                RetDish.Tastiness = uDish.Tastiness;
                RetDish.Description = uDish.Description;
                RetDish.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                System.Console.WriteLine("$$$$$$$$" + RetDish.chefName);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", uDish);
            }
        }
        
        [Route("Delete/{deleteId}")]
        [HttpGet]
        public IActionResult deleteDish(Int32 deleteId)
        {
            MyModel delMe = dbContext.mymodels.SingleOrDefault(dish => dish.MyModelId == deleteId);
            dbContext.mymodels.Remove(delMe);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
