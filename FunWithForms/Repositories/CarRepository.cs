using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FunWithForms.Models
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(AutoContext db) : base(db)
        {
           
        }
    }
}
