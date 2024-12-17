using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Components;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;


namespace WpfApp.ViewModel
{
    public class Ticket_Subscription_InfoViewModel : INotifyPropertyChanged
    {
        private string _purchaseStatus;
        private double _totalPrice;
        private int _ticketCount = 1;
        private string _selectedTicketType;
        private DateTime _selectedDate = DateTime.Now;

        public ObservableCollection<string> TicketOptions { get; } = new ObservableCollection<string>
        {
            "Single Ticket - $2",
            "Round-trip Ticket - $5",
            "Monthly Subscription - $10",
            "6 Months Year Subscription - $30",
            "1 Year Subscription - $50"
        };

        public string SelectedTicketType
        {
            get => _selectedTicketType;
            set
            {
                _selectedTicketType = value;
                OnPropertyChanged();
            }
        }

        public int TicketCount
        {
            get => _ticketCount;
            set
            {
                _ticketCount = value;
                OnPropertyChanged();
            }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        public double TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged();
            }
        }

        public string PurchaseStatus
        {
            get => _purchaseStatus;
            set
            {
                _purchaseStatus = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalculateTotalCommand { get; }
        public ICommand PurchaseTicketsCommand { get; }

        private Ticket newTicket = new Ticket();

        public Ticket_Subscription_InfoViewModel()
        {
            CalculateTotalCommand = new RelayCommand(CalculateTotal);
            PurchaseTicketsCommand = new RelayCommand(PurchaseTickets);
        }

        private void CalculateTotal()
        {
            double pricePerTicket = 0;

            switch (SelectedTicketType)
            {
                case "Single Ticket - $2":
                    pricePerTicket = 2;
                    break;
                case "Round-trip Ticket - $5":
                    pricePerTicket = 5;
                    break;
                case "Monthly Subscription - $10":
                    pricePerTicket = 10;
                    break;
                case "6 Months Year Subscription - $30":
                    pricePerTicket = 30;
                    break;
                case "1 Year Subscription - $50":
                    pricePerTicket = 50;
                    break;
                default:
                    pricePerTicket = 0;
                    break;
            }

            newTicket.ticket_opt = (Ticket_Option)TicketOptions.IndexOf(SelectedTicketType);
            newTicket.ticket_date = SelectedDate;
            newTicket.ticket_price = pricePerTicket;
            newTicket.ticket_count = TicketCount;

            TotalPrice = pricePerTicket * TicketCount;
        }

        private void PurchaseTickets()
        {
            newTicket.AddTicket();
            PurchaseStatus = "Tickets Purchased Successfully!";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
