using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.Components;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(LoginButton);
            RegisterCommand = new RelayCommand(RegisterButton);
        }

        private void LoginButton()
        {
            string username = Username;
            string password = Password;

            if (ServiceUser.Exist_User(username, password))
            {
                // set connected state to true
                LoginModel.Connected= true;
                // navigate to search window
                MainWindow mainWindow = new MainWindow();
                Dictionary<string, string> newLoginDetails = new Dictionary<string, string> { { username, password } };
                ServiceUser.LoginDetails = newLoginDetails;
                NavigationHelper.NavigateTo(typeof(Search));
            }
        }

        private void RegisterButton()
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainContent.Content = new Register();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
