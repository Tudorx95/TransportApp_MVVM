using System.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Components;

namespace WpfApp
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            //DB_Connect.connection(".", Resource1.DB_Name);
            //MessageBox.Show(DB_Connect.connect.ServerVersion.ToString());
            InitializeComponent();

            this.WindowState = WindowState.Maximized; // Maximize the window
            MainContent.Content = new Home();
        }
        
        public void NavigateToPage(Type pageType)
        {
            
            NavigationBar.NavigateTo(pageType);
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Normal)  // Restored down
            {
                // Adjust content here for a "floating" effect, if needed
                MainContent.Margin = new Thickness(20);  // Example adjustment
            }
            else if (WindowState == WindowState.Maximized)
            {
                MainContent.Margin = new Thickness(0);
            }
        }
    }
}