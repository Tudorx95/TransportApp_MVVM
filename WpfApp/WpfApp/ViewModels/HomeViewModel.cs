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

        public HomeViewModel()
        {
            // Initialize Commands with appropriate methods
            OpenTicketSubscriptionCommand = new RelayCommand(OpenTicketSubscription);
            OpenStudentFacilitiesCommand = new RelayCommand(OpenStudentFacilities);
            OpenPupilsFreeCommand = new RelayCommand(OpenPupilsFree);
            OpenComplainsCommand = new RelayCommand(OpenComplains);
        }

        private void OpenTicketSubscription(object obj)
        {
            var infos = new Ticket_Subscription_Info();
            infos.ShowDialog();
        }

        private void OpenStudentFacilities(object obj)
        {
            var facilitiesWindow = new StudentFacilities();
            facilitiesWindow.Show();
        }

        private void OpenPupilsFree(object obj)
        {
            var pupilsWindow = new Pupils_Free();
            pupilsWindow.Show();
        }

        private void OpenComplains(object obj)
        {
            var complainsWindow = new Complains_Request();
            complainsWindow.Show();
        }
    }
}
