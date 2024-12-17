using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Components;

namespace WpfApp.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _username;
        private string _password;
        private string _confirmPassword;

        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set { _confirmPassword = value; OnPropertyChanged(nameof(ConfirmPassword)); }
        }

        // Commands
        public ICommand RegisterCommand { get; }
        public ICommand BackToLoginCommand { get; }

        // Constructor
        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(param => RegisterUser(), param => CanRegister());
            BackToLoginCommand = new RelayCommand(param => BackToLogin());
        }

        // Methods
        private void RegisterUser()
        {
            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (!ServiceUser.IsUsernameUnique(Username))
            {
                MessageBox.Show("Username already exists!");
                return;
            }

            if (ServiceUser.RegisterUser(FirstName, LastName, Email, Username, Password))
            {
                MessageBox.Show("Registration successful!");
                NavigationHelper.NavigateTo(typeof(Login));
            }
            else
            {
                MessageBox.Show("Registration failed!");
            }
        }

        private bool CanRegister() =>
            !string.IsNullOrWhiteSpace(FirstName) &&
            !string.IsNullOrWhiteSpace(LastName) &&
            !string.IsNullOrWhiteSpace(Email) &&
            !string.IsNullOrWhiteSpace(Username) &&
            !string.IsNullOrWhiteSpace(Password) &&
            !string.IsNullOrWhiteSpace(ConfirmPassword);

        private void BackToLogin()
        {
            NavigationHelper.NavigateTo(typeof(Login));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

