using System;
using System.Collections.Generic;

namespace _00_Db_Airplane_
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public Account Account { get; set; }
    }
}
