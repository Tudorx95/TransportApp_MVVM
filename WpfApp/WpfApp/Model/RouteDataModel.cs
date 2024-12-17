using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class RouteDataModel
    {
        public string LeftImage { get; set; }
        public List<StationArrival> Arrivals { get; set; }

        public RouteDataModel(string leftImage, List<StationArrival> arrivals)
        {
            LeftImage = leftImage;
            Arrivals = arrivals;
        }
    }
}
