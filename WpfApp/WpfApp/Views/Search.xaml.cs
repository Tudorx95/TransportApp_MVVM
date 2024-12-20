using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfApp.Components;
using WpfApp.Model;

namespace WpfApp
{
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
        }

        private void LeftImage_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Open the popup when LeftImage is clicked
            ImagePopup.IsOpen = true;
        }

        private void ImagePopup_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Close the popup when it's clicked
            ImagePopup.IsOpen = false;
        }

        private void FindPathButton_Click(object sender, RoutedEventArgs e)
        {
            SearchRoute newWindow = new SearchRoute();
            newWindow.Show();
        }
        
    }
}
