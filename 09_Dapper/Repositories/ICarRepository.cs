using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Dapper.Repositories
{
    public interface ICarRepository
    {
        Car Create(Car car);
        Car Get(int id);
        void Update(Car car);
        void Delete(int id);
        List<Car> GetCars();
    }
}
