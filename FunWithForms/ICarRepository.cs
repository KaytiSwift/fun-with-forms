using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunWithForms.Models;

namespace FunWithForms
{
    public interface ICarRepository
    {
        void Create(Car car);
    }
}
