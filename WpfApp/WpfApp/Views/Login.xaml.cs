using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Components;

namespace WpfApp
{
    public partial class Login : UserControl
    {

        public Login()
        {
            InitializeComponent();
            // Initialize placeholders visibility
            UsernamePlaceholder.Visibility = string.IsNullOrWhiteSpace(UsernameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
            PasswordPlaceholder.Visibility = string.IsNullOrWhiteSpace(PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UsernamePlaceholder.Visibility = Visibility.Collapsed;
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UsernamePlaceholder.Visibility = string.IsNullOrWhiteSpace(UsernameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = string.IsNullOrWhiteSpace(PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        
    }
}
