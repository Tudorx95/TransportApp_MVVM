using System.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Components;
using WpfApp.ViewModels;

namespace WpfApp
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            this.WindowState = WindowState.Maximized; // Maximize the window
            //MainContent.Content = new Home();
        }

        private void MainContent_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            MainContent.DataContext = viewModel;
        }

        //public void NavigateToPage(Type pageType)
        //{

        //    NavigationBar.NavigateTo(pageType);
        //}
        //private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    if (WindowState == WindowState.Normal)  // Restored down
        //    {
        //        // Adjust content here for a "floating" effect, if needed
        //        MainContent.Margin = new Thickness(20);  // Example adjustment
        //    }
        //    else if (WindowState == WindowState.Maximized)
        //    {
        //        MainContent.Margin = new Thickness(0);
        //    }
        //}
    }
}