using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPzTrainLib
{
    public class Params
    {
        public int From { get; set; }
        public int To { get; set; }
        public DateTime Date { get; set; }

        public int MinTicketsCount { get; set; }
        public int MaxArriveTime { get; set; }
    }
}
