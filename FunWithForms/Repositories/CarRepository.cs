using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunWithForms.Models;
using Microsoft.EntityFrameworkCore;

namespace FunWithForms.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(AutoContext db) : base(db)
        {
           
        }
    }
}
