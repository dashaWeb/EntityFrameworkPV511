using System.Collections.Generic;

namespace _00_Db_Airplane_
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassanger { get; set; }
        public string Country { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
