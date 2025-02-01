using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Components
{
    public class Ticket
    {
        public int ticket_count;
        public double ticket_price;
        public Ticket_Option ticket_opt;
        public DateTime ticket_date;
        public double total_Price;
        public Ticket()
        {

        }
        public Ticket(int count, double price, Ticket_Option option, DateTime date)
        {
            ticket_count = count;
            ticket_price = price;
            ticket_opt = option;
        }
        public void determine_Time()
        {
            if (ticket_opt == Ticket_Option.Year_Subscription)
            {
                ticket_date = DateTime.Now.AddYears(1);
            }
            if (ticket_opt == Ticket_Option.Half_Year_Subsc)
            {
                ticket_date = DateTime.Now.AddMonths(6);
            }
            // here the user must have an indicator of outstanding amounts
            // or treat as the user paid for the specific months (n months where n is the nb of months from now to specified date)_
            if (ticket_opt == Ticket_Option.Monthly_Subscription)
            {
                // round to the next mount;
                DateTime startDate = ticket_date;
                DateTime currentDate = DateTime.Now;
                int monthsDifference = ((currentDate.Year - startDate.Year) * 12) + currentDate.Month - startDate.Month;
                if (currentDate.Day < startDate.Day)
                {
                    monthsDifference--; // Subtract one month if the current day hasn't reached the start day yet
                }

                total_Price *= monthsDifference;
            }
            if(ticket_opt==Ticket_Option.Single_Ticket)
            {
                ticket_date=DateTime.Now.AddDays(1);
            }
            if(ticket_opt==Ticket_Option.Round_Trip_Ticket)
            {
                ticket_date = DateTime.Now.AddDays(2);
            }
        }
        private static readonly Dictionary<Ticket_Option, string> TicketOptionMappings = new Dictionary<Ticket_Option, string>
        {
            { Ticket_Option.Single_Ticket, "Bilet o calatorie" },
            { Ticket_Option.Round_Trip_Ticket, "Bilet dus-intors" },
            { Ticket_Option.Monthly_Subscription, "abonament lunar" },
            { Ticket_Option.Half_Year_Subsc, "abonament 6 luni" },
            { Ticket_Option.Year_Subscription, "abonament 1 an" }
        };

        static int Determine_Ticket_ID(Ticket_Option ticket_name)
        {
            if (!TicketOptionMappings.TryGetValue(ticket_name, out var ticketName))
            {
                MessageBox.Show("Invalid ticket option.");
                return -1;
            }

            ticketName = ticketName.ToLower();

            var context = new TransportDBEntities();  // Replace with your actual DataContext name

            try
            {
                // Use LINQ to get the ticket matching the criteria
                var ticket = context.Tip_Bilet
                                    .Where(t => t.nume.ToLower()==ticketName)
                                    .FirstOrDefault();  // Get the first matching ticket or null if no match found

                if (ticket != null)
                {
                    return ticket.id_unic;  // Return the id_unic if a matching ticket is found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return -1;
        }
        public void AddTicket()
        {
            total_Price = ticket_price * ticket_count;
            determine_Time();
            int id_user = ServiceUser.getUserID();
            if (id_user == -1)
            {
                MessageBox.Show($"You are not logged in!");
                return;
            }
            int id_ticket = Determine_Ticket_ID(ticket_opt);
            if (id_ticket == -1)
            {
                MessageBox.Show("Cannot add the ticket. Ticket does not exists in the list");
                return;
            }


            var context = new TransportDBEntities();  // Replace with your actual DataContext name
            bool subm_success = true;
            for (int i = 0; i < ticket_count; i++)
            {
                try
                {
                    // Create a new Bilet entity
                    var newTicket = new Bilet
                    {
                        tip_bilet = id_ticket,  // Use the determined ticket ID
                        valabilitate = ticket_date.Date,  // Format the date as needed
                        id_calator = id_user,  // User ID
                                               //nr_bilete = ticket_count  // Number of tickets
                    };

                    // Add the new ticket to the context
                    context.Bilets.Add(newTicket);

                    // Submit changes to the database
                    context.SaveChanges();

                    // Show success message
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}\n\n{ex.InnerException?.Message}");
                    subm_success = false;
                }
            }
            if(subm_success)
                    MessageBox.Show("Ticket/s successfully added.");
        }
    
        static public void RemoveOldTickets()
        {
            int id_user = ServiceUser.getUserID();
            DateTime currentDate = DateTime.Now.Date;

            try
            {
                using (var context = new TransportDBEntities())
                {
                    // Find tickets for the current user that have an old 'valabilitate' (validity date)
                    var oldTickets = context.Bilets
                        .Where(t => t.id_calator == id_user && t.valabilitate < currentDate)
                        .ToList();

                    // Remove the old tickets
                    if (oldTickets.Any())
                    {
                        context.Bilets.RemoveRange(oldTickets);
                        context.SaveChanges();  // Save the changes to the database
                        //MessageBox.Show("Old tickets removed successfully.");
                    }
                    else
                    {
                        //MessageBox.Show("No old tickets to remove.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
