using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfApp.Components;

namespace WpfApp
{
    public partial class Search : UserControl
    {
        private List<string> sampleSuggestions = new List<string>();
        private Dictionary<string, string> videoMappings = new Dictionary<string, string>();
        private Dictionary<string, (string LeftImage, List<StationArrival> Arrivals)> routeData = new Dictionary<string, (string, List<StationArrival>)>();
        private void LoadVideoMappings()
        {
            using (var context = new DataClasses1DataContext())
            {
                //load tip transport + numar mijloc de transport
                var transportTypes = from tip in context.TipMTs
                                     join mt in context.MTs on tip.id_unic equals mt.id_tip
                                     select new
                                     {
                                         nume = tip.nume + " nr. " + mt.numar_mt
                                     };

                foreach (var transportType in transportTypes)
                {
                    // video paths
                    string videoPath = transportType.nume.Contains("Tramvai")
                        ? Resource.tram_video
                        : transportType.nume.Contains("Autobuz")
                        ? Resource.bus_video
                        : transportType.nume.Contains("Metro")
                        ? Resource.metro_video
                        : null; 

                    if (videoPath != null)
                    {
                        videoMappings.Add(transportType.nume, videoPath);
                    }
                }
            }
        }

        public void LoadSuggestionsFromDatabase()
        {
            var context = new DataClasses1DataContext();
            var suggestions = from tip in context.TipMTs
                              join mt in context.MTs on tip.id_unic equals mt.id_tip
                              select tip.nume + " nr. " + mt.numar_mt;

            sampleSuggestions.Clear();
            sampleSuggestions.AddRange(suggestions);
        }

        private void LoadRouteDataFromDatabase()
        {
            using (var context = new DataClasses1DataContext())
            {
                //dictionar pt toate imaginile cu rute
                var imageMappings = new Dictionary<int, string>
                {
                    { 101, Resource.autouz101 },
                    { 102, Resource.autobuz102 },
                    { 103, Resource.autobuz103 },
                    { 10, Resource.tramvai10 },
                    { 11, Resource.tramvai11 },
                    { 12, Resource.tramvai12 },
                    { 1, Resource.metrou1 }
                };

                //load tip transport + numar mijloc de transport
                var transportTypes = from tip in context.TipMTs
                                     join mt in context.MTs on tip.id_unic equals mt.id_tip
                                     select new
                                     {
                                         TransportName = tip.nume + " nr. " + mt.numar_mt,
                                         TransportType = tip.nume,
                                         NumarMT = mt.numar_mt,
                                         IdTraseu = mt.nr_traseu
                                     };

                // Curăță datele anterioare
                routeData.Clear();

                foreach (var transportType in transportTypes)
                {
                    // Extrage datele despre sosiri pentru fiecare traseu
                    var arrivals = (from statie in context.Staties
                                    join tipStatie in context.Tip_Staties on statie.id_tip_statie equals tipStatie.id_unic
                                    where statie.id_traseu == transportType.IdTraseu
                                    select new StationArrival(
                                        tipStatie.nume,       
                                        statie.ore.Split(' ').ToList() 
                                    )).ToList();

                    // construieste calea pt imagine
                    string imagePath;
                    if (imageMappings.ContainsKey(transportType.NumarMT))
                    {
                        imagePath = imageMappings[transportType.NumarMT];
                    }
                    else
                    {
                        imagePath = "Images/default_transport.png";
                    }

                    routeData.Add(transportType.TransportName, (imagePath, arrivals));
                }
            }
        }

        public Search()
        {
            LoadSuggestionsFromDatabase();
            LoadRouteDataFromDatabase(); // Load route data from the database
            InitializeComponent();
            LoadVideoMappings();
            Media.Play();
            LeftImage.MouseLeftButtonUp += LeftImage_MouseLeftButtonUp;
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FloatingLabel.Visibility = Visibility.Collapsed;
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                FloatingLabel.Visibility = Visibility.Visible;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = SearchTextBox.Text;

            var filteredSuggestions = sampleSuggestions
                .Where(suggestion => suggestion.StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            SuggestionsListBox.ItemsSource = filteredSuggestions;
            SuggestionsListBox.Visibility = filteredSuggestions.Any() ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SuggestionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SuggestionsListBox.SelectedItem != null)
            {
                string selectedSuggestion = SuggestionsListBox.SelectedItem.ToString();
                SearchTextBox.Text = selectedSuggestion;
                SuggestionsListBox.Visibility = Visibility.Collapsed;
                FloatingLabel.Visibility = Visibility.Collapsed;

                if (routeData.ContainsKey(selectedSuggestion))
                {
                    var routeInfo = routeData[selectedSuggestion];

                    // Set the images and station list based on the selected option
                    LeftImage.Source = new BitmapImage(new Uri(routeInfo.LeftImage, UriKind.Relative));
                    LeftImage.Visibility = Visibility.Visible;

                    // Set data for the DataGrid
                    StationsDataGrid.ItemsSource = routeInfo.Arrivals;

                    // Set visibility for RouteDisplay
                    RouteDisplay.Visibility = Visibility.Visible; 

                    // Dynamically set the video source
                    SetVideoSource(selectedSuggestion);
                }
                else
                {
                    // Clear data if no route found
                    LeftImage.Source = null;
                    LeftImage.Visibility = Visibility.Collapsed;
                    StationsDataGrid.Visibility = Visibility.Collapsed;
                    RouteDisplay.Visibility = Visibility.Collapsed; 

                    Media.Source = null; // Stop video if no transport type is selected
                }

            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Searching for: {SearchTextBox.Text}");
        }

        private void LeftImage_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Open the popup when LeftImage is clicked
            ImagePopup.IsOpen = true;
        }

        private void ImagePopup_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Close the popup when it's clicked
            ImagePopup.IsOpen = false;
        }

        private void SetVideoSource(string transportType)
        {
            // Check if the transportType exists in the videoMappings dictionary
            if (videoMappings.TryGetValue(transportType, out string videoPath))
            {
                Media.Source = new Uri(videoPath); 
                Media.Play(); 
            }
            else
            {
                Media.Source = null;
                MessageBox.Show($"No video available for transport type: {transportType}");
            }
        }

        private void Media_MediaEnded(object sender, RoutedEventArgs e)
        {
            // event
            Media.Position = TimeSpan.Zero; 
            Media.Play(); 
        }
        private void FindPathButton_Click(object sender, RoutedEventArgs e)
        {
            SearchRoute newWindow = new SearchRoute();
            newWindow.Show();
        }

        // Class to represent station arrival times
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
}
