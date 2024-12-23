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
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Net;
using System.Data.Entity;

namespace WpfApp.ViewModels
{
    // ViewModel class
    public class SearchRouteViewModel : INotifyPropertyChanged
    {
        private readonly TransportDBEntities _dbContext;
        private ObservableCollection<StationInfo> _stations;
        private Point? _startingPoint;
        private Point? _destinationPoint;
        private string _instructionText;
        private bool _isGenerateRouteButtonVisible;
        private string _closestStationsMessage;
        private Cursor _cursor;
        private string _mousePosition;
        private ObservableCollection<string> _routes;

        public ObservableCollection<StationInfo> Stations
        {
            get => _stations;
            set
            {
                _stations = value;
                OnPropertyChanged();
            }
        }

        public Point? StartingPoint
        {
            get => _startingPoint;
            set
            {
                _startingPoint = value;
                OnPropertyChanged();
            }
        }

        public Point? DestinationPoint
        {
            get => _destinationPoint;
            set
            {
                _destinationPoint = value;
                OnPropertyChanged();
            }
        }

        public string InstructionText
        {
            get => _instructionText;
            set
            {
                _instructionText = value;
                OnPropertyChanged();
            }
        }

        public bool IsGenerateRouteButtonVisible
        {
            get => _isGenerateRouteButtonVisible;
            set
            {
                _isGenerateRouteButtonVisible = value;
                OnPropertyChanged();
            }
        }

        public string ClosestStationsMessage
        {
            get => _closestStationsMessage;
            set
            {
                _closestStationsMessage = value;
                OnPropertyChanged();
            }
        }

        public Cursor Cursor
        {
            get => _cursor;
            set
            {
                _cursor = value;
                OnPropertyChanged();
            }
        }

        public string MousePosition
        {
            get => _mousePosition;
            set
            {
                _mousePosition = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Routes
        {
            get => _routes;
            set
            {
                _routes = value;
                OnPropertyChanged();
            }
        }

        public ICommand MapMouseDownCommand { get; }
        public ICommand ResetCommand { get; }
        public ICommand GenerateRouteCommand { get; }

        public event Action ClearPins;
        public event Action<string> ShowMessage;
        public event Action<Point> AddPinRequested;










        //initial stuff
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public SearchRouteViewModel()
        {
            _dbContext = new TransportDBEntities();

            Stations = new ObservableCollection<StationInfo>();
            LoadStations();

            MapMouseDownCommand = new RelayCommand<Point>(OnMapMouseDown);
            InstructionText = "Please select the starting location.";
            IsGenerateRouteButtonVisible = false;
            ResetCommand = new RelayCommand(argv => ResetSelection());
            Cursor = Cursors.Arrow;
            GenerateRouteCommand = new RelayCommand(argv => GenerateRoute());
            Routes = new ObservableCollection<string>();
        }
        private async void LoadStations()
        {
            // Fetch station data asynchronously
            var stationList = await Task.Run(() => FetchStationsFromDatabase());
            foreach (var station in stationList)
            {
                Stations.Add(station);
            }
        }
        private List<StationInfo> FetchStationsFromDatabase()
        {
            using (var context = new TransportDBEntities())
            {
                // Fetch raw data from the database
                var stations = context.Coordonate_Statie
                    .Include(coord => coord.Tip_Statie) // Eagerly load Tip_Statie navigation property
                    .Select(coord => new
                    {
                        StationId = coord.id_statie,
                        StationName = coord.Tip_Statie.nume,
                        CoordX = coord.coord_X,
                        CoordY = coord.coord_Y
                    })
                    .ToList(); // Materialize the query into memory

                // Map to StationInfo after data is in memory
                return stations.Select(station => new StationInfo
                {
                    Id = station.StationId.Value,
                    Name = station.StationName,
                    Coordinates = new Point(station.CoordX, station.CoordY) // Constructor usage is safe here
                }).ToList();
            }
        }

        public void OnMapMouseDown(Point clickedPoint)
        {
            if (StartingPoint == null && DestinationPoint == null)
            {
                InstructionText = "Please select the starting location.";
            }

            if (clickedPoint.X >= 0 && clickedPoint.Y >= 0)
            {
                if (StartingPoint == null)
                {
                    ShowDistance(clickedPoint);
                    StartingPoint = clickedPoint;
                    RequestPin(clickedPoint);
                    InstructionText = "Please select the destination location.";
                }
                else if (DestinationPoint == null)
                {
                    ShowDistance(clickedPoint);
                    DestinationPoint = clickedPoint;
                    InstructionText = "Both locations already selected.";
                    RequestPin(clickedPoint);
                }
                else
                {
                    MessageBox.Show("Both locations already selected.");
                }
            }

            // Show the Generate Route button if both points are selected
            IsGenerateRouteButtonVisible = StartingPoint.HasValue && DestinationPoint.HasValue;
        }
        private void ResetSelection()
        {
            StartingPoint = null;
            DestinationPoint = null;

            // Notify UI that pins should be cleared via a property binding or event
            ClearPins?.Invoke();

            InstructionText = "Please select the starting location.";
        }
        public void ShowDistance(Point clickedPoint)
        {
            var distances = Stations
                .Select(station => new
                {
                    Station = station,
                    Distance = CalculateDistance(clickedPoint, station.Coordinates)
                })
                .OrderBy(x => x.Distance)
                .Take(3)
                .ToList();

            string message = "The 3 closest stations are:\n" +
                             string.Join("\n", distances.Select(d => $"{d.Station.Name} - Distance: {d.Distance:F2} km"));

            ShowMessage?.Invoke(message);
        }

        private double CalculateDistance(Point p1, Point p2)
        {
            return Math.Round((Math.Round(Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)), 2) * 10) / 1000, 2);
        }
        public void OnMapMouseEnter()
        {
            Cursor = Cursors.Cross;
        }

        public void OnMapMouseLeave()
        {
            Cursor = Cursors.Arrow;
        }
        public void UpdateMousePosition(Point position)
        {
            MousePosition = $"Mouse Position: {position.X:F2}, {position.Y:F2}";
        }

        public void RequestPin(Point clickedPoint)
        {
            // Trigger the event to notify the View
            AddPinRequested?.Invoke(clickedPoint);
        }
        private bool CanGenerateRoute()
        {
            return StartingPoint.HasValue && DestinationPoint.HasValue;
        }

        private void GenerateRoute()
        {
            Routes.Clear();

            var startStations = Stations
                .Select(station => new
                {
                    Station = station,
                    Distance = CalculateDistance(StartingPoint.Value, station.Coordinates)
                })
                .OrderBy(x => x.Distance)
                .Take(3)
                .ToList();

            var destinationStations = Stations
                .Select(station => new
                {
                    Station = station,
                    Distance = CalculateDistance(DestinationPoint.Value, station.Coordinates)
                })
                .OrderBy(x => x.Distance)
                .Take(3)
                .ToList();

            var routeSet = new HashSet<string>();
            bool routeFound = false;

            foreach (var startStation in startStations)
            {
                foreach (var destinationStation in destinationStations)
                {
                    var route = FindBestRoute(startStation.Station.Name, destinationStation.Station.Name);

                    if (route != null && route.Any() && route.Count > 1)
                    {
                        string routeKey = string.Join(" -> ", route.Select(s => s.Name));

                        if (routeSet.Add(routeKey))
                        {
                            routeFound = true;

                            // Add the route header
                            Routes.Add($"Route from {startStation.Station.Name} to {destinationStation.Station.Name}:");

                            // Add the stations in the route
                            foreach (var station in route)
                            {
                                Routes.Add($"  • {station.Name}");
                            }
                        }
                    }
                }
            }

            double walkingDistance = CalculateDistance(StartingPoint.Value, DestinationPoint.Value);
            Routes.Add($"Walking Distance: {walkingDistance:F2} km");
        }
        private List<StationInfo> FindBestRoute(string startStationName, string endStationName)
        {
            // 1. Find the start and end stations by name
            var startStation = _dbContext.Tip_Statie.FirstOrDefault(s => s.nume == startStationName);
            var endStation = _dbContext.Tip_Statie.FirstOrDefault(s => s.nume == endStationName);

            if (startStation == null || endStation == null)
            {
                ShowMessage?.Invoke("One of the stations does not exist.");
                return null;
            }

            // 2. Get the routes that contain each station
            var startStationRoutes = _dbContext.Staties
                .Where(s => s.id_tip_statie == startStation.id_unic)
                .ToList();

            var endStationRoutes = _dbContext.Staties
                .Where(s => s.id_tip_statie == endStation.id_unic)
                .ToList();

            // 3. Find intersecting routes
            var intersectingRoutes = startStationRoutes
                .Where(startRoute => endStationRoutes
                    .Any(endRoute => endRoute.id_traseu == startRoute.id_traseu))
                .Select(route => route.id_traseu)
                .Distinct()
                .ToList();

            if (!intersectingRoutes.Any())
            {
                return null;
            }

            List<StationInfo> shortestRoute = null;

            foreach (var routeId in intersectingRoutes)
            {
                // 4. Get all stations on the current route, ordered
                var stationsOnRoute = _dbContext.Staties
                    .Where(s => s.id_traseu == routeId)
                    .OrderBy(s => s.id_unic)
                    .Select(s => new StationInfo
                    {
                        Id = s.id_unic,
                        Name = s.Tip_Statie.nume,
                        //Coordinates = new Point(s.coord_X, s.coord_Y) // Add coordinates if available
                    })
                    .ToList();

                int startIndex = stationsOnRoute.FindIndex(s => s.Name == startStationName);
                int endIndex = stationsOnRoute.FindIndex(s => s.Name == endStationName);

                if (startIndex == -1 || endIndex == -1) continue;

                // 5. Create lists for direct and circular routes
                List<StationInfo> directRoute;
                List<StationInfo> circularRoute;

                if (startIndex <= endIndex)
                {
                    directRoute = stationsOnRoute.Skip(startIndex).Take(endIndex - startIndex + 1).ToList();
                }
                else
                {
                    directRoute = stationsOnRoute.Skip(startIndex).Concat(stationsOnRoute.Take(endIndex + 1)).ToList();
                }

                circularRoute = stationsOnRoute.Skip(startIndex)
                                               .Concat(stationsOnRoute.Take(endIndex + 1))
                                               .ToList();

                // Choose the shortest route
                var candidateRoute = directRoute.Count <= circularRoute.Count ? directRoute : circularRoute;

                // Update the shortest route
                if (shortestRoute == null || candidateRoute.Count < shortestRoute.Count)
                {
                    shortestRoute = candidateRoute;
                }
            }

            if (shortestRoute == null || !shortestRoute.Any())
            {
                return null;
            }

            return shortestRoute;
        }

    }
}