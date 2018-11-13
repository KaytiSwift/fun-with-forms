using FunWithForms.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithForms.Controllers
{
    public class CarsController : Controller
    {
        private ICarRepository carRepo;

        public CarsController(ICarRepository carRepo)
        {
            this.carRepo = carRepo;
        }

        public IActionResult Index()
        {
            var cars = carRepo.GetAll();
            return View(cars);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car newCar)
        {
            carRepo.Create(newCar);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var car = carRepo.GetById(id);
            return View(car);
        }

        public IActionResult Delete(int id)
        {
            var car = carRepo.GetById(id);
            return View(car);
        }

        [HttpPost]
        [ActionName("Delete")]        
        public IActionResult DeletePost(int id)
        {
            carRepo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var car = carRepo.GetById(id);
            return View(car);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit(Car car)
        {
            carRepo.Update(car);
            return RedirectToAction("Index");
        }
    }
}
