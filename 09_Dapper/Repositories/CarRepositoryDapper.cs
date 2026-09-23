using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Dapper.Repositories
{
    public class CarRepositoryDapper : ICarRepository
    {
        string connectionString;
        public CarRepositoryDapper(string conn)
        {
            this.connectionString = conn;
        }
        public Car Create(Car car)
        {
            using(IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(@"insert into Cars (Make, Model, ModelYear) 
                                values(@Make, @Model, @ModelYear)", car);
                return car;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(@"delete from Cars where Id = @id", new {id});
            }
        }

        public Car Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.QueryFirstOrDefault<Car>(@"select* from Cars where Id = @id", new { id });
            }
        }

        public List<Car> GetCars()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Car>(@"select* from Cars").ToList();
            }
        }

        public void Update(Car car)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(@"update Cars set Make = @Make, Model = @Model, ModelYear = @ModelYear where Id = @Id", car );
            }
        }
    }
}
