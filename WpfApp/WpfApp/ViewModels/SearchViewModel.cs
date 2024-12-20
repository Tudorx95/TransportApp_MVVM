using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using WpfApp.Model;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        private readonly TransportDBEntities context = new TransportDBEntities();

        // Properties
        public ObservableCollection<string> Suggestions { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<StationArrival> Stations { get; set; } = new ObservableCollection<StationArrival>();

        static public Visibility BoolToVisibilityConverter;
        

        private string _selectedSuggestion;
        public string SelectedSuggestion
        {
            get => _selectedSuggestion;
            set
            {
                _selectedSuggestion = value;
                OnPropertyChanged(nameof(SelectedSuggestion));
                LoadRouteData();
            }
        }

        private string _leftImagePath;
        public string LeftImagePath
        {
            get => _leftImagePath;
            set
            {
                _leftImagePath = value;
                OnPropertyChanged(nameof(LeftImagePath));
            }
        }

        private Uri _videoSource;
        public Uri VideoSource
        {
            get => _videoSource;
            set
            {
                _videoSource = value;
                OnPropertyChanged(nameof(VideoSource));
            }
        }

        // Commands
        public ICommand SearchCommand { get; }

        // Constructor
        public SearchViewModel()
        {
            LoadSuggestions();
            SearchCommand = new RelayCommand(ExecuteSearch);
        }

        // Load Suggestions
        private void LoadSuggestions()
        {
            var suggestions = context.TipMTs
                .Join(context.MTs,
                    tip => tip.id_unic,
                    mt => mt.id_tip,
                    (tip, mt) => new { tip.nume, mt.numar_mt })
                .ToList();

            Suggestions.Clear();
            foreach (var suggestion in suggestions)
            {
                Suggestions.Add($"{suggestion.nume} nr. {suggestion.numar_mt}");
            }
        }

        // Load Route Data when Suggestion is Selected
        private void LoadRouteData()
        {
            if (string.IsNullOrEmpty(SelectedSuggestion)) return;

            var route = context.TipMTs
                .Join(context.MTs,
                    tip => tip.id_unic,
                    mt => mt.id_tip,
                    (tip, mt) => new
                    {
                        FullName = tip.nume + " nr. " + mt.numar_mt,
                        ImagePath = "Images/default_transport.png",
                        IdTraseu = mt.nr_traseu
                    })
                .FirstOrDefault(r => r.FullName == SelectedSuggestion);

            if (route != null)
            {
                // Load station arrivals
                var stationArrivals = context.Staties
                    .Join(context.Tip_Statie,
                        statie => statie.id_tip_statie,
                        tipStatie => tipStatie.id_unic,
                        (statie, tipStatie) => new
                        {
                            statie.id_traseu,
                            tipStatie.nume,
                            statie.ore
                        })
                    .Where(s => s.id_traseu == route.IdTraseu)
                    .ToList();

                Stations.Clear();
                foreach (var arrival in stationArrivals)
                {
                    var arrivalTimes = arrival.ore.Split(' ').ToList();
                    Stations.Add(new StationArrival(arrival.nume, arrivalTimes));
                }

                LeftImagePath = route.ImagePath;
            }
        }

        private void ExecuteSearch(object parameter)
        {
            // Action for Search Button
            Console.WriteLine($"Searching for: {SelectedSuggestion}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Media_MediaEnded(object sender, RoutedEventArgs e)
        {
            // Reset video to start from the beginning
            MediaElement media = sender as MediaElement;
            if (media != null)
            {
                media.Position = TimeSpan.Zero;
                media.Play();
            }
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private Visibility isFloatingLabelVisible;

        public Visibility IsFloatingLabelVisible { get => isFloatingLabelVisible; set => SetProperty(ref isFloatingLabelVisible, value); }

        private Visibility isLeftImageVisible;

        public Visibility IsLeftImageVisible { get => isLeftImageVisible; set => SetProperty(ref isLeftImageVisible, value); }

        private Visibility isRouteVisible;

        public Visibility IsRouteVisible { get => isRouteVisible; set => SetProperty(ref isRouteVisible, value); }

    }
}
