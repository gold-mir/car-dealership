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

        [HttpGet("/new/")]
        public ActionResult New()
        {
            return View();
        }

        [HttpGet("/cars/{id}")]
        public ActionResult Details(int id)
        {
            Car car = Car.GetByID(id);
            if(car != null)
            {
                return View(car);
            } else
            {
                return View("Error");
            }
        }

        [HttpPost("cars/{id}/notes")]
        public ActionResult AddNote(int id)
        {
            Car car = Car.GetByID(id);
            if(car != null)
            {
                car.AddNote(Request.Form["new-note"]);
                return View("Details", car);
            } else
            {
                return View("Error");
            }
        }
    }
}
