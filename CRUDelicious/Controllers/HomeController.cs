using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {

        private MyContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            var dishes = dbContext.Dishes.ToList();
            return View(dishes);
        }

        [HttpGet("{id}")]
        public IActionResult SingleView(int id)
        {
            var displayMe = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);
            return View(displayMe);
        }

        public IActionResult Removealldish()
        {
            List<Dish> all = dbContext.Dishes.Select(x => x).ToList();
            foreach (var d in all)
            {
                dbContext.Dishes.Remove(d);
            }
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("passedId")]
        public IActionResult serveEdit(int passedId)
        {
            var getForEdit = dbContext.Dishes.FirstOrDefault(thing => thing.DishId == passedId);
            return View(getForEdit);
        }

        [HttpPost("doneEditing/passedId")]
        public IActionResult doneEditing(Dish theDish, int passedId)
        {

            if (ModelState.IsValid)
            {
                var grab = dbContext.Dishes.FirstOrDefault(x => x.DishId == theDish.DishId);
                dbContext.Entry(grab).CurrentValues.SetValues(theDish);
                dbContext.SaveChanges();
                var compare = dbContext.Dishes.FirstOrDefault(x => x.DishId == theDish.DishId);
                var stop = true;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("serveEdit");
            }

            //dbContext.Dishes.FirstOrDefault(theDish);

        }


        public IActionResult Delete(int theIdToDelete)
        {
            var grab = dbContext.Dishes.FirstOrDefault(x => x.DishId == theIdToDelete);
            dbContext.Dishes.Remove(grab);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult NewDish()
        {
            return View();
        }
        [HttpPost("NewDishDisplay")]
        public IActionResult NewDishDisplay(Dish incomingDish)
        {

            if (ModelState.IsValid)
            {
                dbContext.Dishes.Add(incomingDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View("NewDish");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
