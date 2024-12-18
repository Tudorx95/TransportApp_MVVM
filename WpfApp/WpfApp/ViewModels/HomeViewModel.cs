using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class HomeViewModel
    {
        public ICommand OpenTicketSubscriptionCommand { get; }
        public ICommand OpenStudentFacilitiesCommand { get; }
        public ICommand OpenPupilsFreeCommand { get; }
        public ICommand OpenComplainsCommand { get; }
        public ICommand NavigateCommand { get; }

        public HomeViewModel()
        {
            // Initialize Commands with appropriate methods
            NavigateCommand = new RelayCommand(NavigateToComponent);
        }
        private void NavigateToComponent(object parameter)
        {
            // Use the parameter to determine the button clicked
            if (parameter is string buttonName)
            {
                switch (buttonName)
                {
                    case "Ticket/subscription":
                        OpenTicketSubscription();
                        break;
                    case "Student facilities":
                        OpenStudentFacilities();
                        break;
                    case "Pupils free":
                        OpenPupilsFree();
                        break;
                    case "Complains":
                        OpenComplains();
                        break;
                    default:
                        // Handle unexpected input
                        break;
                }
            }
        }
        private void OpenTicketSubscription()
        {
            var infos = new Ticket_Subscription_Info();
            infos.ShowDialog();
        }

        private void OpenStudentFacilities()
        {
            var facilitiesWindow = new StudentFacilities();
            facilitiesWindow.Show();
        }

        private void OpenPupilsFree()
        {
            var pupilsWindow = new Pupils_Free();
            pupilsWindow.Show();
        }

        private void OpenComplains()
        {
            var complainsWindow = new Complains_Request();
            complainsWindow.Show();
        }
    }
}
