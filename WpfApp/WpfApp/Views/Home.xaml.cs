using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Components;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
       public Home()
       {
           InitializeComponent();
            this.Loaded += Home_Loaded;

        }
        private void Home_Loaded(object sender, RoutedEventArgs e)
        {
            var storyboard = (Storyboard)this.Resources["BusAnimationStoryboardReverse"];
            storyboard.Begin();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string buttonContent = clickedButton.Content.ToString();

            switch (buttonContent)
            {
                case "Ticket/subscription":
                    Ticket_Subscription_Info infos= new Ticket_Subscription_Info();
                    infos.ShowDialog();
                    break;
                case "Student facilities":
                    //MainContent.Content = new FacilitiesUser Control();
                    StudentFacilities facilitiesWindow = new StudentFacilities();
                    facilitiesWindow.Show();
                    break;
                case "Pupils free":
                    // Load PupilsFreeUser Control
                    Pupils_Free pupils_facilities= new Pupils_Free();
                    pupils_facilities.Show();
                    break;
                case "Complains":
                    // Load ComplainsUser Control
                    Complains_Request req = new Complains_Request();
                    req.Show();
                    break;
                default:
                    MainContent.Content = null;
                    break;
            }
        }
    }
}
