using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Windows.Controls;
using WpfApp.Model;

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
    }
}