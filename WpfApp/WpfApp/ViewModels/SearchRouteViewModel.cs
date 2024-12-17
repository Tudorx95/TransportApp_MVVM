using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using WpfApp.Model;

namespace WpfApp.ViewModels
{
    // ViewModel class
    public class SearchRouteViewModel : INotifyPropertyChanged
    {
        private readonly TransportDBEntities _context;

        private Point? _startingPoint;
        private Point? _destinationPoint;
        public ObservableCollection<StationInfo> Stations { get; set; } = new ObservableCollection<StationInfo>();

        public ICommand MapMouseDownCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand GenerateRouteCommand { get; set; }

        private string _instructionText;
        public string InstructionText
        {
            get => _instructionText;
            set
            {
                _instructionText = value;
                OnPropertyChanged(nameof(InstructionText));
            }
        }

        private ObservableCollection<string> _routeDetails = new ObservableCollection<string>();
        public ObservableCollection<string> RouteDetails
        {
            get => _routeDetails;
            set
            {
                _routeDetails = value;
                OnPropertyChanged(nameof(RouteDetails));
            }
        }

        public SearchRouteViewModel()
        {
            _context = new TransportDBEntities();
            InitializeStations();

            MapMouseDownCommand = new RelayCommand<Point>(OnMapMouseDown);
            ResetCommand = new RelayCommand(param => OnReset());
            GenerateRouteCommand = new RelayCommand(param => OnGenerateRoute());

            InstructionText = "Please select the starting location.";
        }

        private void InitializeStations()
        {
            var stationCoordinates = from coord in _context.Coordonate_Statie.AsEnumerable()
                                     join tip in _context.Tip_Statie on coord.id_statie equals tip.id_unic
                                     select new StationInfo
                                     {
                                         Name = tip.nume,
                                         Coordinates = new Point(coord.coord_X, coord.coord_Y)
                                     };

            foreach (var station in stationCoordinates)
                Stations.Add(station);
        }

        private void OnMapMouseDown(Point clickedPoint)
        {
            if (_startingPoint == null)
            {
                _startingPoint = clickedPoint;
                InstructionText = "Please select the destination location.";
            }
            else if (_destinationPoint == null)
            {
                _destinationPoint = clickedPoint;
                InstructionText = "Both locations already selected.";
            }
        }

        private void OnReset()
        {
            _startingPoint = null;
            _destinationPoint = null;
            InstructionText = "Please select the starting location.";
            RouteDetails.Clear();
        }

        private void OnGenerateRoute()
        {
            if (_startingPoint == null || _destinationPoint == null)
                return;

            var startStations = FindClosestStations(_startingPoint.Value);
            var destinationStations = FindClosestStations(_destinationPoint.Value);

            var routeSet = new HashSet<string>();
            bool routeFound = false;
            RouteDetails.Clear();

            foreach (var startStation in startStations)
            {
                foreach (var destinationStation in destinationStations)
                {
                    List<StationInfo> route = FindBestRoute(startStation.Name, destinationStation.Name);

                    if (route != null && route.Count > 1)
                    {
                        string routeKey = string.Join(" -> ", route.Select(s => s.Name));

                        if (routeSet.Add(routeKey))
                        {
                            routeFound = true;
                            RouteDetails.Add($"Route from {startStation.Name} to {destinationStation.Name}:");
                            foreach (var station in route)
                            {
                                RouteDetails.Add($"  {station.Name}");
                            }
                        }
                    }
                }
            }

            if (!routeFound)
            {
                RouteDetails.Add("No route found between the selected stations.");
            }
        }

        private List<StationInfo> FindClosestStations(Point point)
        {
            return Stations
                .Select(station => new
                {
                    Station = station,
                    Distance = CalculateDistance(point, station.Coordinates)
                })
                .OrderBy(x => x.Distance)
                .Take(3)
                .Select(x => x.Station)
                .ToList();
        }

        private List<StationInfo> FindBestRoute(string startStationName, string endStationName)
        {
            var startStation = _context.Tip_Statie.FirstOrDefault(s => s.nume == startStationName);
            var endStation = _context.Tip_Statie.FirstOrDefault(s => s.nume == endStationName);

            if (startStation == null || endStation == null)
                return null;

            var startRoutes = _context.Staties.Where(s => s.id_tip_statie == startStation.id_unic).ToList();
            var endRoutes = _context.Staties.Where(s => s.id_tip_statie == endStation.id_unic).ToList();

            var intersectingRoutes = startRoutes.Where(startRoute => endRoutes.Any(endRoute => endRoute.id_traseu == startRoute.id_traseu))
                                                .Select(route => route.id_traseu)
                                                .Distinct()
                                                .ToList();

            foreach (var routeId in intersectingRoutes)
            {
                var stationsOnRoute = _context.Staties.Where(s => s.id_traseu == routeId)
                                                     .OrderBy(s => s.id_unic)
                                                     .Select(s => new StationInfo { Name = s.Tip_Statie.nume })
                                                     .ToList();

                int startIndex = stationsOnRoute.FindIndex(s => s.Name == startStationName);
                int endIndex = stationsOnRoute.FindIndex(s => s.Name == endStationName);

                if (startIndex <= endIndex)
                    return stationsOnRoute.Skip(startIndex).Take(endIndex - startIndex + 1).ToList();
            }

            return null;
        }

        private double CalculateDistance(Point p1, Point p2)
        {
            return Math.Round(Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)) / 100, 2);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
