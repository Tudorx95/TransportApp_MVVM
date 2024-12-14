using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Implement login logic here
            // Example: if (ServiceUser.Exist_User(Username, Password)) { ... }
            string username = _username;
            string password = _password;

            //string encryptedPassword = Crypt.Encrypt(password);
            // verify the integrity of the password

            if (ServiceUser.Exist_User(username, password))
            {
                // set connected state to true
                Login.connected = true;
                // navigate to search window
                MainWindow mainWindow = new MainWindow();
                Dictionary<string, string> newLoginDetails = new Dictionary<string, string> { { username, password } };
                ServiceUser.LoginDetails = newLoginDetails;
                NavigationBar.NavigateTo(typeof(Search));
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
