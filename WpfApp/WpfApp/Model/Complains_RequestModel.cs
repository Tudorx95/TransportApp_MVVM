using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Model
{
    public class Complains_RequestModel
    {
        static public void Insert_Complain(int id_user, string text, int id_MTC_type, string selectedService)
        {
            var context = new TransportDBEntities();
            try
            {
                // Create a new Complaint object and set its properties
                var newComplaint = new Complaint
                {
                    id_user = id_user,
                    text_plangere = text,
                    id_tip_MTC = id_MTC_type
                };

                // Insert the new Complaint object into the table
                context.Complaints.Add(newComplaint);

                // Submit changes to the database
                context.SaveChanges();

                MessageBox.Show($"Your complaint about {selectedService} has been sent!", "Complaint Submitted", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the database operation
                MessageBox.Show($"{ex.Message} in Insert_Complain");
            }
        }
    }
}
