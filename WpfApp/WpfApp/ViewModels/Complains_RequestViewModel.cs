using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WpfApp.Components;
using System.Windows.Controls;
using WpfApp.Model;

namespace WpfApp.ViewModels
{
    public class Complains_RequestViewModel : INotifyPropertyChanged
    {
        private string _selectedService;
        private string _complainText;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> Services { get; set; }

        public string SelectedService
        {
            get => _selectedService;
            set
            {
                _selectedService = value;
                OnPropertyChanged(nameof(SelectedService));
            }
        }

        public string ComplainText
        {
            get => _complainText;
            set
            {
                _complainText = value;
                OnPropertyChanged(nameof(ComplainText));
            }
        }

        public ICommand SubmitCommand { get; set; }

        public Complains_RequestViewModel()
        {
            // Populate services list
            Services = new ObservableCollection<string> { "Bus Service", "Tram Service", "Trolleybus", "Subway" };

            SubmitCommand = new RelayCommand(SendComplaint);
        }

        private void SendComplaint(object parameter)
        {
            if (string.IsNullOrEmpty(SelectedService) || string.IsNullOrEmpty(ComplainText))
            {
                MessageBox.Show("Please select a service and enter your complaint before submitting.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string username = ServiceUser.LoginDetails.FirstOrDefault().ToString();
            string password = ServiceUser.LoginDetails.FirstOrDefault().ToString();
            if (username == "" || password == "")
            {
                MessageBox.Show("Please log in before you submit any complain!");
                return;
            }
            // Get selected service from ComboBox
            var selectedService = SelectedService;


            // Get the text entered in the TextBox
            var complainMessage = ComplainText;

            if (string.IsNullOrEmpty(selectedService) || string.IsNullOrEmpty(complainMessage))
            {
                MessageBox.Show("Please select a service and enter your complaint before submitting.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            int id_user = ServiceUser.getUserID();
            int id_mtc = MTC.Get_MTC_Type(selectedService);
            if (id_user == -1)
            {
                MessageBox.Show($"You must log in to send a complaint!");
                return;
            }
            Complains_RequestModel.Insert_Complain(id_user, complainMessage, id_mtc, selectedService);

            // Optionally clear the fields after submission
            SelectedService = null;
            ComplainText = string.Empty;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
