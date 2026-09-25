using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Db_Airplane_
{
    public static class DbInitializer
    {
        public static void SeedAirplane(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
                new Airplane()
                {
                    Id = 1,
                    Model = "Boing747",
                    MaxPassanger = 1200
                },
                new Airplane()
                {
                    Id = 2,
                    Model = "AN914",
                    MaxPassanger = 1200
                },
                new Airplane()
                {
                    Id = 3,
                    Model = "Mria",
                    MaxPassanger = 1200
                },
            });
        }
        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[]{
                new Flight()
                {
                    Number = 1,
                    DepartureCity = "Kyiv",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2026,09,19),
                    ArrivalTime = new DateTime(2026,09,20),
                    AirplaneId = 1
                },
                new Flight()
                {
                    Number = 2,
                    DepartureCity = "Varshava",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2026,09,21),
                    ArrivalTime = new DateTime(2026,09,22),
                    AirplaneId = 2
                },
                new Flight()
                {
                    Number = 3,
                    DepartureCity = "Rivne",
                    ArrivalCity = "Kyiv",
                    DepartureTime = new DateTime(2026,09,21),
                    ArrivalTime = new DateTime(2026,09,21),
                    AirplaneId = 3
                },
            });
        }

        public static void SeedAccounts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account[] {
                new Account()
                {
                    Id = 1,
                    Login = "Admin",
                    Password = "Admin",
                    ClientId = 1
                },
                new Account()
                {
                    Id = 2,
                    Login = "User",
                    Password = "User",
                    ClientId = 2
                },
                new Account()
                {
                    Id = 3,
                    Login = "Entity",
                    Password = "Entity",
                    ClientId = 3
                },
            });
        }

        public static void SeedClients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(new Client[] {
                new Client()
                {
                    Id = 1,
                    Name = "Alex",
                    Email = "alex@gmail.com"
                },
                new Client()
                {
                    Id = 2,
                    Name = "Olena",
                    Email = "olena@gmail.com"
                },
                new Client()
                {
                    Id = 3,
                    Name = "Oleg",
                    Email = "oleg@gmail.com"
                },
            });
        }
    }
}
