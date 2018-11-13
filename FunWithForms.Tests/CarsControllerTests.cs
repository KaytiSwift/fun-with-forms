using FunWithForms.Controllers;
using FunWithForms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;


namespace FunWithForms.Tests
{
    public class CarsControllerTests
    {
        
        private Car car;
        private ICarRepository carRepo;
        private CarsController underTest;

        public CarsControllerTests()
        {
            car = new Car();
            carRepo = Substitute.For<ICarRepository>();
            underTest = new CarsController(carRepo);
        }

        [Fact]
        public void Create_And_Saves()
        {
            

            underTest.Create(car);

            carRepo.Received().Create(car);
        }

        [Fact]
        public void Create_Redirects_to_Index_After_Creating()
        {
            

            var result = underTest.Create(car);

            //Assert.IsType<RedirectToActionResult>(result);
            var redirctResult = (RedirectToActionResult)result;

            Assert.Same("Index", redirctResult.ActionName);
        }

        [Fact]
        public void Index_Passes_All_Cars_To_View()
        {
            var expectedCars = new List<Car>();
            carRepo.GetAll().Returns(expectedCars);

            var result = underTest.Index();
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCars, model);
        }

        [Fact]
        public void Details_Passes_Correct_Car_To_view()
        {

            var expectedCar = new Car();
            var carId = 42;
            carRepo.GetById(carId).Returns(expectedCar);

            var result = underTest.Details(carId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCar, model);
        }

        [Fact]
        public void Delete_Passes_Correct_Car_To_view()
        {

            var expectedCar = new Car();
            var carId = 42;
            carRepo.GetById(carId).Returns(expectedCar);

            var result = underTest.Delete(carId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCar, model);
        }

        [Fact]
        public void Delete_Post_Deletes_the_Car()
        {
            var carId = 42;

            underTest.DeletePost(carId);

            carRepo.Received().Delete(carId);
        }

        [Fact]
        public void Delete_Redirects_to_Index_After_Deleting()
        {


            var result = underTest.DeletePost(42);

            //Assert.IsType<RedirectToActionResult>(result);
            var redirctResult = (RedirectToActionResult)result;

            Assert.Same("Index", redirctResult.ActionName);
        }

        [Fact]
        public void Update_Passes_Existing_Car_To_View()
        {
            var carId = 42;
            var expectedCar = new Car();
            carRepo.GetById(carId).Returns(expectedCar);

            var result = underTest.Edit(carId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCar, model);
        }

        [Fact]
        public void Edit_Saves_Updated_Car()
        {
            underTest.Edit(car);

            carRepo.Received().Update(car);
        }

        [Fact]
        public void Edit_Redirects_To_Index()
        {
            var result = underTest.Edit(car);

            //Assert.IsType<RedirectToActionResult>(result);
            var redirctResult = (RedirectToActionResult)result;

            Assert.Same("Index", redirctResult.ActionName);
        }
    }
}
