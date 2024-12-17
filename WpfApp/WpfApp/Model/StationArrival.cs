using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class StationArrival
    {
        public string StationName { get; set; }
        public List<string> ArrivalTimes { get; set; }

        public string ArrivalTimesDisplay => string.Join(", ", ArrivalTimes);

        public StationArrival(string stationName, List<string> arrivalTimes)
        {
            StationName = stationName;
            ArrivalTimes = arrivalTimes;
        }
    }
}
