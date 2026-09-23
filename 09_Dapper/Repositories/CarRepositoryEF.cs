using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Dapper.Repositories
{
    public class CarDbModel : DbContext
    {
        string connectionString;
        public CarDbModel(string connectionString)
        {
            this.connectionString = connectionString;
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@$"{connectionString}");
        }
        public virtual DbSet<Car> Cars { get; set; }
    }
    public class CarRepositoryEF : ICarRepository
    {
        CarDbModel context = null;
        public CarRepositoryEF(string connectionString)
        {
            context = new CarDbModel(connectionString);
        }
        public Car Create(Car car)
        {
            var add = context.Cars.Add(car);
            context.SaveChanges();
            return add.Entity;
        }

        public void Delete(int id)
        {
            var car = context.Cars.Find(id);
            if(car != null)
            {
                context.Cars.Remove(car);
                context.SaveChanges();
            }
        }

        public Car Get(int id)
        {
            return context.Cars.Find(id);
        }

        public List<Car> GetCars()
        {
            return context.Cars.ToList();
        }

        public void Update(Car car)
        {
            context.Entry(car).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
