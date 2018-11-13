using FunWithForms.Controllers;
using FunWithForms.Models;
using NSubstitute;
using System;
using Xunit;


namespace FunWithForms.Tests
{
    public class CarsControllerTests
    {
        [Fact]
        public void Post_And_Saves()
        {
            var car = new Car();
            var carRepo = Substitute.For<ICarRepository>();
            var underTest = new CarsController(carRepo);

            underTest.Create(car);

            carRepo.Received().Create(car);
        }
    }
}
