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

        [HttpPost("cars/{id}/notes/")]
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

        [HttpGet("cars/{id}/notes/{noteID}")]
        public ActionResult ViewNote(int carID, int noteID)
        {
            Car car = Car.GetByID(carID);
            Note note = null;
            foreach (Note item in car.GetNotes())
            {
                if(item.GetID() == noteID){
                    note = item;
                }
            }
            if(note != null)
            {
                return View(note);
            } else
            {
                return View("Error");
            }
        }

        [HttpPost("cars/{id}/notes/{noteID}")]
        public ActionResult AddMetaNote(int carID, int noteID)
        {
            Car car = Car.GetByID(carID);
            Note note = null;
            foreach (Note item in car.GetNotes())
            {
                if(item.GetID() == noteID){
                    note = item;
                }
            }
            if(note != null)
            {
                note.AddNote(new Note(Request.Form["new-note"]));
                return View("ViewNote", note);
            } else
            {
                return View("Error");
            }
        }
    }
}
