using Microsoft.Xaml.Behaviors.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfApp.Components;
using WpfApp.Model;

namespace WpfApp.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        private Visibility _floatingLabelVisibility = Visibility.Visible;
        public Visibility FloatingLabelVisibility
        {
            get => _floatingLabelVisibility;
            set
            {
                _floatingLabelVisibility = value;
                OnPropertyChanged();
            }
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();

                    // Update FloatingLabel visibility dynamically
                    FloatingLabelVisibility = string.IsNullOrWhiteSpace(_searchText) ? Visibility.Visible : Visibility.Collapsed;

                    // Update filtered suggestions
                    UpdateFilteredSuggestions();
                }
            }
        }

        private ObservableCollection<string> _filteredSuggestions = new ObservableCollection<string>();
        public ObservableCollection<string> FilteredSuggestions
        {
            get => _filteredSuggestions;
            private set
            {
                _filteredSuggestions = value;
                OnPropertyChanged();
            }
        }
        private string _selectedSuggestion;
        public string SelectedSuggestion
        {
            get => _selectedSuggestion;
            set
            {
                if (_selectedSuggestion != value)
                {
                    _selectedSuggestion = value;
                    OnPropertyChanged();

                    // Handle selection changes
                    HandleSelectedSuggestion();
                }
            }
        }
        private string _leftImageSource;
        public string LeftImageSource
        {
            get => _leftImageSource;
            set
            {
                _leftImageSource = value;
                OnPropertyChanged();
            }
        }

        private Visibility _leftImageVisibility = Visibility.Collapsed;
        public Visibility LeftImageVisibility
        {
            get => _leftImageVisibility;
            set
            {
                _leftImageVisibility = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<StationArrival> _stations;
        public ObservableCollection<StationArrival> Stations
        {
            get => _stations;
            set
            {
                _stations = value;
                OnPropertyChanged();
            }
        }
        private Visibility _routeDisplayVisibility = Visibility.Collapsed;
        public Visibility RouteDisplayVisibility
        {
            get => _routeDisplayVisibility;
            set
            {
                _routeDisplayVisibility = value;
                OnPropertyChanged();
            }
        }
        private string _videoSource;
        public string VideoSource
        {
            get => _videoSource;
            set
            {
                _videoSource = value;
                OnPropertyChanged();
            }
        }
        public ICommand SearchCommand { get; }
        public ICommand OpenPopupCommand { get; }
        public ICommand ClosePopupCommand { get; }

        private bool _isPopupOpen;
        public bool IsPopupOpen
        {
            get => _isPopupOpen;
            set
            {
                _isPopupOpen = value;
                OnPropertyChanged();
            }
        }
        public ICommand MediaEndedCommand { get; }
        private TimeSpan _mediaPosition;
        public TimeSpan MediaPosition
        {
            get => _mediaPosition;
            set
            {
                _mediaPosition = value;
                OnPropertyChanged();
            }
        }

        private bool _isPlaying;
        public bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                _isPlaying = value;
                OnPropertyChanged();
            }
        }
        public ICommand OpenSearchRouteCommand { get; }
        public ICommand MediaStartCommand { get; }






        //initial stuff
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public SearchViewModel()
        {
            SearchCommand = new RelayCommand(argv => ExecuteSearchCommand());
            OpenPopupCommand = new RelayCommand(argv => ExecuteOpenPopupCommand());
            ClosePopupCommand = new RelayCommand(argv => ExecuteClosePopupCommand());
            OpenSearchRouteCommand = new RelayCommand(argv => ExecuteOpenSearchRouteCommand());
            MediaEndedCommand = new RelayCommand(parameter => ExecuteMediaEndedCommand(parameter));
            MediaStartCommand = new RelayCommand(parameter => ExecuteMediaStartCommand(parameter));

            // Initialize properties here
            LoadVideoMappings();
            LoadSuggestionsFromDatabase();
            LoadRouteDataFromDatabase();
        }

        public ObservableCollection<string> SampleSuggestions { get; set; } = new ObservableCollection<string>();
        public Dictionary<string, string> VideoMappings { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, (string LeftImage, List<StationArrival> Arrivals)> RouteData { get; set; } = new Dictionary<string, (string, List<StationArrival>)>();

        public void LoadVideoMappings()
        {
            VideoMappings.Clear(); // Clear previous data

            using (var context = new TransportDBEntities())
            {
                var transportTypes = context.TipMTs
                    .Join(context.MTs,
                          tip => tip.id_unic,
                          mt => mt.id_tip,
                          (tip, mt) => new
                          {
                              Name = tip.nume + " nr. " + mt.numar_mt,
                              VideoPath = tip.nume.Contains("Tramvai") ? Resource.tram_video :
                                          tip.nume.Contains("Autobuz") ? Resource.bus_video :
                                          tip.nume.Contains("Metro") ? Resource.metro_video : null
                          })
                    .Where(x => !string.IsNullOrEmpty(x.VideoPath))
                    .ToList();

                foreach (var type in transportTypes)
                {
                    VideoMappings[type.Name] = type.VideoPath;
                }
            }

            // Notify the UI of changes
            OnPropertyChanged(nameof(VideoMappings));
        }


        public void LoadSuggestionsFromDatabase()
        {
            SampleSuggestions.Clear(); // Clear previous data

            using (var context = new TransportDBEntities())
            {
                // Query the database using Entity Framework
                var suggestions = context.TipMTs
                    .Join(context.MTs,
                          tip => tip.id_unic,
                          mt => mt.id_tip,
                          (tip, mt) => tip.nume + " nr. " + mt.numar_mt)
                    .ToList();

                // Populate the observable collection
                foreach (var suggestion in suggestions)
                {
                    SampleSuggestions.Add(suggestion);
                }
            }

            // Notify the UI of changes
            OnPropertyChanged(nameof(SampleSuggestions));
        }

        public void LoadRouteDataFromDatabase()
        {
            RouteData.Clear(); // Clear previous data

            using (var context = new TransportDBEntities())
            {
                // Define image mappings
                var imageMappings = new Dictionary<int, string>
                {
                    { 101, Resource.autobuz102 },
                    { 102, Resource.autobuz102 },
                    { 103, Resource.autobuz103 },
                    { 10, Resource.tramvai10 },
                    { 11, Resource.tramvai11 },
                    { 12, Resource.tramvai12 },
                    { 1, Resource.metrou1 }
                };

                // Query transport types
                var transportTypes = context.TipMTs
                    .Join(context.MTs,
                          tip => tip.id_unic,
                          mt => mt.id_tip,
                          (tip, mt) => new
                          {
                              Name = tip.nume + " nr. " + mt.numar_mt,
                              RouteId = mt.nr_traseu,
                              Number = mt.numar_mt
                          })
                    .ToList();

                // Process each transport type
                foreach (var transport in transportTypes)
                {
                    // Fetch raw data from the database
                    var rawArrivals = context.Staties
                        .Join(context.Tip_Statie,
                              statie => statie.id_tip_statie,
                              tipStatie => tipStatie.id_unic,
                              (statie, tipStatie) => new
                              {
                                  StationName = tipStatie.nume,
                                  ArrivalTimes = statie.ore,
                                  RouteId = statie.id_traseu
                              })
                        .Where(x => x.RouteId == transport.RouteId)
                        .ToList(); // Materialize into memory

                    // Map the raw data to StationArrival objects
                    var arrivals = rawArrivals
                        .Select(x => new StationArrival(
                            x.StationName,
                            x.ArrivalTimes.Split(' ').ToList()))
                        .ToList();


                    // Get image path
                    string imagePath = imageMappings.ContainsKey(transport.Number)
                        ? imageMappings[transport.Number]
                        : "Images/default_transport.png";

                    // Populate RouteData
                    RouteData[transport.Name] = (imagePath, arrivals);
                }
            }

            // Notify the UI
            OnPropertyChanged(nameof(RouteData));
        }
        private void UpdateFilteredSuggestions()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredSuggestions.Clear();
                return;
            }

            var filtered = SampleSuggestions
                .Where(suggestion => suggestion.StartsWith(SearchText, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            FilteredSuggestions.Clear();
            foreach (var suggestion in filtered)
            {
                FilteredSuggestions.Add(suggestion);
            }
        }
        private void HandleSelectedSuggestion()
        {
            if (string.IsNullOrEmpty(SelectedSuggestion))
            {
                // Reset data if no suggestion is selected
                LeftImageSource = null;
                LeftImageVisibility = Visibility.Collapsed;
                Stations = null;
                RouteDisplayVisibility = Visibility.Collapsed;
                VideoSource = null;
                return;
            }

            // Set search text dynamically
            SearchText = SelectedSuggestion;

            // Check if the selected suggestion exists in RouteData
            if (RouteData.ContainsKey(SelectedSuggestion))
            {
                var routeInfo = RouteData[SelectedSuggestion];

                // Update UI-related properties
                LeftImageSource = routeInfo.LeftImage;
                LeftImageVisibility = Visibility.Visible;
                Stations = new ObservableCollection<StationArrival>(routeInfo.Arrivals);
                RouteDisplayVisibility = Visibility.Visible;

                // Use SetVideoSource for video source handling
                SetVideoSource(SelectedSuggestion);
            }
            else
            {
                // Reset data for invalid suggestions
                LeftImageSource = null;
                LeftImageVisibility = Visibility.Collapsed;
                Stations = null;
                RouteDisplayVisibility = Visibility.Collapsed;
                VideoSource = null; // Clear video source
            }
        }

        private void ExecuteSearchCommand()
        {
            MessageBox.Show($"Searching for: {SearchText}");
        }
        private void ExecuteOpenPopupCommand()
        {
            IsPopupOpen = true; // Open the popup
        }

        private void ExecuteClosePopupCommand()
        {
            IsPopupOpen = false; // Close the popup
        }
        public void SetVideoSource(string transportType)
        {
            if (VideoMappings.TryGetValue(transportType, out string videoPath))
            {
                VideoSource = videoPath; // Update the bound property
            }
            else
            {
                VideoSource = null; // Clear the video source
                MessageBox.Show($"No video available for transport type: {transportType}");
            }
        }
        private void ExecuteMediaEndedCommand(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            if (mediaElement != null)
            {
                mediaElement.Position = TimeSpan.Zero; // Reset position
                mediaElement.Play(); // Restart playback
            }
        }
        private void ExecuteOpenSearchRouteCommand()
        {
            // Open the SearchRoute window
            SearchRoute newWindow = new SearchRoute();
            newWindow.Show();
        }
        private void ExecuteMediaStartCommand(object parameter)
        {
            var mediaElement = parameter as MediaElement;
            if (mediaElement != null)
            {
                mediaElement.Position = TimeSpan.Zero; // Reset to the start
                mediaElement.Play(); // Start playback
            }
        }

    }
}