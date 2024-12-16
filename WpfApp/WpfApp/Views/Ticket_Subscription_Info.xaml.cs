using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Components;

namespace WpfApp
{
    public enum Ticket_Option
    {
        Single_Ticket, Round_Trip_Ticket, Monthly_Subscription, Half_Year_Subsc, Year_Subscription
    }
    public partial class Ticket_Subscription_Info : Window
    {
        Ticket newticket = new Ticket();
        public Ticket_Subscription_Info()
        {
            InitializeComponent();
        }

        private void CalculateTotal_Click(object sender, RoutedEventArgs e)
        {
            double pricePerTicket = 0;
            switch (TicketTypeComboBox.SelectedIndex)
            {
                case 0: // Single Ticket
                    pricePerTicket = 2;
                    newticket.ticket_opt= Ticket_Option.Single_Ticket;
                    break;
                case 1: // Monthly Subscription
                    pricePerTicket = 5;
                    newticket.ticket_opt = Ticket_Option.Round_Trip_Ticket;
                    break;
                case 2: // Annual Subscription
                    pricePerTicket = 10;
                    newticket.ticket_opt = Ticket_Option.Monthly_Subscription;
                    break;
                case 3:
                    pricePerTicket=30;
                    newticket.ticket_opt = Ticket_Option.Half_Year_Subsc;
                    break;
                case 4:
                    pricePerTicket=50;
                    newticket.ticket_opt = Ticket_Option.Year_Subscription;
                    break;
            }
            // Extract the selected date from the calendar
            if (TicketDateCalendar.SelectedDate.HasValue)
            {
                newticket.ticket_date= TicketDateCalendar.SelectedDate.Value;
            }
            else
            {
                // Default to today's date if no date is selected
                newticket.ticket_date = DateTime.Now;
            }

            int ticketCount = (int)TicketCountSlider.Value;
            double totalPrice = pricePerTicket * ticketCount;
            newticket.ticket_price = pricePerTicket;
            newticket.ticket_count = ticketCount;
            TotalPriceTextBlock.Text = $"Total Price: ${totalPrice}";
        }

        private void PurchaseTickets_Click(object sender, RoutedEventArgs e)
        {
            // Create a ticket with nb_ticket buyed, ticket price, and ticket name
            newticket.AddTicket();
            PurchaseStatusTextBlock.Text = "Tickets Purchased Successfully!";
        }
    }
}