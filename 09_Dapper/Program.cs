using _09_Dapper.Repositories;
using System;
using System.Diagnostics;

namespace _09_Dapper
{
    
    class Program
    {
        static Stat TestProvider(ICarRepository repos)
        {
            var result = new Stat();
            Stopwatch sw;

            // Read one
            sw = Stopwatch.StartNew();
            repos.Get(78);
            sw.Stop();
            result.ReadByIdTime = sw.ElapsedMilliseconds;

            // Read all
            sw = Stopwatch.StartNew();
            repos.GetCars();
            sw.Stop();
            result.ReadAllTime = sw.ElapsedMilliseconds;

            // create
            sw = Stopwatch.StartNew();
            Car car = repos.Create(new Car()
            {
                Make = "Audi",
                Model = "A6",
                ModelYear = 2006
            }
            );
            sw.Stop();
            result.CreateTime = sw.ElapsedMilliseconds;

            // update
            car.Model = "New Model";
            sw = Stopwatch.StartNew();
            repos.Update(car);
            sw.Stop();
            result.UpdateTime = sw.ElapsedMilliseconds;

            //delete 
            sw = Stopwatch.StartNew();
            repos.Delete(car.Id);
            sw.Stop();
            result.DeleteTime = sw.ElapsedMilliseconds;

            foreach (var stat in result.GetType().GetProperties())
            {
                Console.WriteLine($"{stat.Name} :: {stat.GetValue(result)}ms");
            }
            return result;
        }
        static void Main(string[] args)
        {
            string conn = @"data source = (localdb)\MSSQLLocalDB; Initial Catalog = CarSalon; Integrated security = True; Connect Timeout = 2";

            Console.WriteLine("\n-------------- Entity Framework Core -------------");
            TestProvider(new CarRepositoryEF(conn));
            Console.WriteLine("\n-------------------  ADO.NET ---------------------");
            TestProvider(new CarRepositoryADO_NET(conn));
            Console.WriteLine("\n--------------------  Dapper ----------------------");
            TestProvider(new CarRepositoryDapper(conn));
        }
    }
}
