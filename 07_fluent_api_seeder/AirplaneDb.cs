using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_fluent_api_seeder
{
    class AirplaneDb : DbContext
    {
        public AirplaneDb()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"
                            Data Source = (localdb)\MSSQLLocalDB;
                            Initial Catalog = Airplane_PV_511;
                            Integrated Security = True;
                            Connect Timeout = 2;");
        }
    }

    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassanger { get; set; }
        public string Country { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public Account Account { get; set; }
    }

    public class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }
    }

    public class Flight
    {
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }

        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
