using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using WpfApp.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp
{
    public partial class SearchRoute : Window
    {
        private SearchRouteViewModel _viewModel;

        public SearchRoute()
        {
            InitializeComponent();

            // Instantiate the ViewModel and subscribe to events
            _viewModel = new SearchRouteViewModel();
            _viewModel.ClearPins += OnClearPins;
            _viewModel.ShowMessage += OnShowMessage;
            _viewModel.AddPinRequested += OnAddPinRequested;

            // Set the ViewModel as the DataContext
            DataContext = _viewModel;
        }

        // Event handler to clear the PinCanvas
        private void OnClearPins()
        {
            PinCanvas.Children.Clear();
        }

        // Event handler to display a message
        private void OnShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler to add a pin to the canvas
        private void OnAddPinRequested(Point clickedPoint)
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
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var position = e.GetPosition(MapImage);
            _viewModel.UpdateMousePosition(position);
        }
        private void OnMapImageMouseDown(object sender, MouseButtonEventArgs e)
        {
            var clickedPoint = e.GetPosition(MapImage);
            _viewModel.OnMapMouseDown(clickedPoint);
        }
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (DataContext is SearchRouteViewModel viewModel)
            {
                viewModel.OnMapMouseEnter();
            }
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (DataContext is SearchRouteViewModel viewModel)
            {
                viewModel.OnMapMouseLeave();
            }
        }

    }
}