using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunWithForms.Models;

namespace FunWithForms//FunWithAndrey
{
    public interface ICarRepository
    {
        void Create(Car car);
        IEnumerable<Car> GetAll();
        Car GetById(int id);
        void Delete(int carId);
    }
}
