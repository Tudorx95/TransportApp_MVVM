using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class SearchRoute : Window
    {
        // List to hold station information
        private List<StationInfo> stations = new List<StationInfo>();
        private Point? startingPoint = null;
        private Point? destinationPoint = null;

        public SearchRoute()
        {
            InitializeComponent();
            MapImage.MouseEnter += MapImage_MouseEnter;
            MapImage.MouseLeave += MapImage_MouseLeave;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize stations from the database
            InitializeStations();
        }

        private void InitializeStations()
        {
            using (var context = new DataClasses1DataContext())
            {
                var stationCoordinates = from coord in context.Coordonate_Staties.AsEnumerable()
                                         join tip in context.Tip_Staties on coord.id_statie equals tip.id_unic
                                         select new
                                         {
                                             StationId = coord.id_statie,
                                             StationName = tip.nume, // Get the station name
                                             coord.coord_X,
                                             coord.coord_Y
                                         };

                foreach (var station in stationCoordinates)
                {
                    stations.Add(new StationInfo
                    {
                        Name = station.StationName,
                        Coordinates = new Point(station.coord_X, station.coord_Y)
                    });
                }
            }
        }

        private void MapImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (startingPoint == null && destinationPoint == null)
            {
                InstructionTextBlock.Text = "Please select the starting location.";
            }
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point clickedPoint = e.GetPosition(MapImage);

                if (clickedPoint.X >= 0 && clickedPoint.X <= MapImage.ActualWidth &&
                    clickedPoint.Y >= 0 && clickedPoint.Y <= MapImage.ActualHeight)
                {
                    if (startingPoint == null)
                    {
                        ShowDistance(clickedPoint);
                        startingPoint = clickedPoint;
                        AddPinPoint(clickedPoint); // pin pentru plecare
                        InstructionTextBlock.Text = "Please select the destination location.";
                    }
                    else if (destinationPoint == null)
                    {
                        ShowDistance(clickedPoint);
                        destinationPoint = clickedPoint;
                        AddPinPoint(clickedPoint); // pin pentru destinatie
                        InstructionTextBlock.Text = "Both locations already selected.";
                    }
                    else
                    {
                        MessageBox.Show("Both locations already selected.");
                        InstructionTextBlock.Text = "Both locations already selected.";
                    }
                }
            }
            // genereaza ruta 
            if (startingPoint.HasValue && destinationPoint.HasValue)
            {
                GenerateRouteButton.Visibility = Visibility.Visible;
            }
        }
        private void ResetSelection()
        {
            startingPoint = null;
            destinationPoint = null;
            PinCanvas.Children.Clear();
            InstructionTextBlock.Text = "Please select the starting location.";
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetSelection();
        }


        private void ShowDistance(Point clickedPoint)
        {
            var distances = stations
                .Select(station => new
                {
                    Station = station,
                    Distance = CalculateDistance(clickedPoint, station.Coordinates)
                })
                .OrderBy(x => x.Distance)
                .Take(3) 
                .ToList();

            string message = "The 3 closest stations are:\n";
            foreach (var item in distances)
            {
                message += $"{item.Station.Name} - Distance: {item.Distance:F2} km\n";
            }

            message += "\nDo you want to select this location?";

            MessageBoxResult result = MessageBox.Show(message, "Confirm Location", MessageBoxButton.YesNo, MessageBoxImage.Question);

        }

        private void MapImage_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Cross; 
        }

        private void MapImage_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void MapImage_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(MapImage);
            CoordinatesTextBlock.Text = $"Mouse Position: {mousePosition.X:F2}, {mousePosition.Y:F2}";
        }

        private double CalculateDistance(Point p1, Point p2)
        {
            return Math.Round((Math.Round(Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)), 2) * 10) / 1000, 2);
        }

        private void AddPinPoint(Point clickedPoint)
        {
            Ellipse pin = new Ellipse
            {
                Width = 20,
                Height = 20,
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            PinCanvas.Children.Add(pin);

            Canvas.SetLeft(pin, clickedPoint.X - (pin.Width / 2));
            Canvas.SetTop(pin, clickedPoint.Y - (pin.Height / 2));
        }
        private void GenerateRouteButton_Click(object sender, RoutedEventArgs e)
        {
            RouteDisplayPanel.Children.Clear();

            var startStations = stations
                .Select(station => new
                {
                    Station = station,
                    Distance = CalculateDistance(startingPoint.Value, station.Coordinates)
                })
                .OrderBy(x => x.Distance)
                .Take(3)
                .ToList();

            var destinationStations = stations
                .Select(station => new
                {
                    Station = station,
                    Distance = CalculateDistance(destinationPoint.Value, station.Coordinates)
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
                    List<StationInfo> route = FindBestRoute(startStation.Station.Name, destinationStation.Station.Name);

                    if (route != null && route.Any() && route.Count > 1) 
                    {
                        string routeKey = string.Join(" -> ", route.Select(s => s.Name));

                        if (routeSet.Add(routeKey))
                        {
                            routeFound = true;

                            TextBlock routeTitle = new TextBlock
                            {
                                Text = $"Route from {startStation.Station.Name} to {destinationStation.Station.Name}",
                                FontSize = 14,
                                FontWeight = FontWeights.Bold,
                                Foreground = Brushes.DarkGreen,
                                Margin = new Thickness(0, 0, 20, 5)
                            };
                            RouteDisplayPanel.Children.Add(routeTitle);

                            foreach (var station in route)
                            {
                                TextBlock stationText = new TextBlock
                                {
                                    Text = $"• {station.Name}",
                                    FontSize = 12,
                                    Margin = new Thickness(20, 0, 0, 0)
                                };
                                RouteDisplayPanel.Children.Add(stationText);
                            }
                        }
                    }
                }
            }

            double walkingDistance = CalculateDistance(startingPoint.Value, destinationPoint.Value);
            TextBlock walkingDistanceText = new TextBlock
            {
                Text = $"Walking Distance: {walkingDistance} km",
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.DarkGreen,
                Margin = new Thickness(0, 0, 20, 0)
            };
            RouteDisplayPanel.Children.Add(walkingDistanceText);
        }


        private List<StationInfo> FindBestRoute(string startStationName, string endStationName)
        {
            using (var context = new DataClasses1DataContext())
            {
                // 1. cautam id-ul unic al statiilor
                var startStation = (from tip in context.Tip_Staties
                                    where tip.nume == startStationName
                                    select tip).FirstOrDefault();

                var endStation = (from tip in context.Tip_Staties
                                  where tip.nume == endStationName
                                  select tip).FirstOrDefault();

                if (startStation == null || endStation == null)
                {
                    MessageBox.Show("Una dintre statii nu exista.");
                    return null;
                }

                // 2. obtinem traseele ce contin fiecare statie
                var startStationRoutes = (from statie in context.Staties
                                          where statie.id_tip_statie == startStation.id_unic
                                          select statie).ToList();

                var endStationRoutes = (from statie in context.Staties
                                        where statie.id_tip_statie == endStation.id_unic
                                        select statie).ToList();

                // 3. cautam intersectiile dintre trasee daca sunt
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
                    // 4. obtinem statiile pentru traseul curent si le ordonam
                    var stationsOnRoute = (from statie in context.Staties
                                           where statie.id_traseu == routeId
                                           orderby statie.id_unic
                                           select new StationInfo
                                           {
                                               Id = statie.id_unic,
                                               Name = statie.Tip_Statie.nume
                                           }).ToList();

                    int startIndex = stationsOnRoute.FindIndex(s => s.Name == startStationName);
                    int endIndex = stationsOnRoute.FindIndex(s => s.Name == endStationName);

                    if (startIndex == -1 || endIndex == -1) continue;

                    // 5. creeam lista in fucntie de directie
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
                                                   .Concat(stationsOnRoute.Take(startIndex == 0 ? 0 : endIndex + 1))
                                                   .ToList();

                    // o alegem pe cea mai scurta 
                    var candidateRoute = directRoute.Count <= circularRoute.Count ? directRoute : circularRoute;

                    // 6. actualizam ruta cea mai scurta 
                    if (shortestRoute == null || candidateRoute.Count < shortestRoute.Count)
                    {
                        shortestRoute = candidateRoute;
                    }
                }

                if (shortestRoute == null || !shortestRoute.Any())
                {
                    return null;
                }

                // afisam traseul gasit in consola //debug :)
                foreach (var station in shortestRoute)
                {
                    Console.WriteLine($"Stație: {station.Name}");
                }

                return shortestRoute;
            }
        }

        // Class to hold station information
        public class StationInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Point Coordinates { get; set; }
        }
    }
}