using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Dapper
{
    class Stat
    {
        public long ReadByIdTime { get; set; }
        public long ReadAllTime { get; set; }
        public long CreateTime { get; set; }
        public long DeleteTime { get; set; }
        public long UpdateTime { get; set; }

    }
}
