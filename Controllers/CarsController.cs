using Microsoft.AspNetCore.Mvc;
using CarDealership.Models;
using System;

namespace CarDealership.Controllers
{
    public class CarsController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View(Car.GetAll());
        }

        [HttpPost("/")]
        public ActionResult AddCar()
        {
            string makeModel = Request.Form["make-model"];
            int price = int.Parse(Request.Form["price"]);
            int milage = int.Parse(Request.Form["milage"]);
            Car newCar = new Car(makeModel, price, milage);
            newCar.SetDescription(Request.Form["description"]);

            return View("index", Car.GetAll());
        }

        [HttpGet("/new")]
        public ActionResult New()
        {
            return View();
        }
    }
}
