using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Dapper.Repositories
{
    public class CarRepositoryADO_NET : ICarRepository
    {
        string connectionString = null;
        public CarRepositoryADO_NET(string conn)
        {
            connectionString = conn;
        }
        public Car Create(Car car)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = @"insert into Cars (Make, Model, ModelYear) 
                                values(@Make,@Model,@ModelYear)";
                SqlCommand command = new SqlCommand(cmdText, conn);
                command.Parameters.Add("@Make", SqlDbType.NVarChar).Value = car.Make;
                command.Parameters.Add("@Model", SqlDbType.NVarChar).Value = car.Model;
                command.Parameters.Add("@ModelYear", SqlDbType.Int).Value = car.ModelYear;
                command.ExecuteNonQuery();
                return car;
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = "delete from Cars where Id = @Id";
                SqlCommand command = new SqlCommand(cmdText, conn);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public Car Get(int id)
        {
            Car car= null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string cmdText = @"select * from Cars where Id = @id";
                SqlCommand command = new SqlCommand(cmdText, conn);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    car = new Car()
                    {
                        Make = reader.GetString(1),
                        Model = reader.GetString(2),
                        ModelYear = reader.GetInt32(3),
                        Id = id
                    };
                }
                reader.Close();
                return car;
            }
        }

        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string cmdText = @"select * from Cars";
                SqlCommand command = new SqlCommand(cmdText, conn);
                
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cars.Add(new Car()
                    {
                        Make = reader.GetString(1),
                        Model = reader.GetString(2),
                        ModelYear = reader.GetInt32(3),
                    });
                }
                reader.Close();
                return cars;
            }
        }

        public void Update(Car car)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = @"update Cars set 
                                        Make = @Make,
                                        Model = @Model,
                                        ModelYear = @ModelYear
                                        where Id = @Id";

                SqlCommand command = new SqlCommand(cmdText, conn);
                command.Parameters.Add("@Make", SqlDbType.NVarChar).Value = car.Make;
                command.Parameters.Add("@Model", SqlDbType.NVarChar).Value = car.Model;
                command.Parameters.Add("@ModelYear", SqlDbType.Int).Value = car.ModelYear;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = car.Id;
                command.ExecuteNonQuery();
            }
        }
    }
}
