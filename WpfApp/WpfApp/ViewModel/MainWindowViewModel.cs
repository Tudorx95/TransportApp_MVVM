using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace WpfApp.ViewModel
{
    public class MainWindowViewModel: BaseViewModel
    {
        private object _currentContent;
        public object CurrentContent
        {
            get { return _currentContent; }
            set
            {
                _currentContent = value;
                OnPropertyChanged(nameof(CurrentContent));
            }
        }

        public ICommand NavigateCommand { get; }

        public MainWindowViewModel()
        {
            // Initialize the current content as the Home view
            CurrentContent = new Home();

            // Define the Navigate command to handle navigation
            NavigateCommand = new RelayCommand<Type>(NavigateToPage);
        }

        // Handle navigation to different pages
        private void NavigateToPage(Type pageType)
        {
            if (pageType == typeof(Home))
            {
                CurrentContent = new Home(); // Change content to Home
            }
            else if (pageType == typeof(Search))
            {
                CurrentContent = new Search(); // Change content to Search
            }
            // Add more navigation logic as necessary
        }
    }
}
