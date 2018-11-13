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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car newCar)
        {
            carRepo.Create(newCar);
            return View();
        }
    }
}
