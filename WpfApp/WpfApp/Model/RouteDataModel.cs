using System.Collections.ObjectModel;

namespace WpfApp.Model
{
    public class RouteDataModel
    {
        public string TransportName { get; set; }
        public string ImagePath { get; set; }
        public ObservableCollection<StationArrival> Arrivals { get; set; } = new ObservableCollection<StationArrival>();

        public RouteDataModel(string transportName, string imagePath, ObservableCollection<StationArrival> arrivals)
        {
            TransportName = transportName;
            ImagePath = imagePath;
            Arrivals = arrivals ?? new ObservableCollection<StationArrival>(); // Safeguard in case null is passed
        }
    }
}
