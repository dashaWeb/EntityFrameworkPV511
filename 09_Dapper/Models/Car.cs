using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Dapper
{
    public class Car
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Make { get; set; }
        [Required,MaxLength(50)]
        public string Model { get; set; }
        public int ModelYear { get; set; }
    }
}
