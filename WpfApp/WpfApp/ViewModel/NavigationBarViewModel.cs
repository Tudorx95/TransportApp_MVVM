using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp.Components;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class NavigationBarViewModel : BaseViewModel
    {
        public string Logo { get; } = Resource.logoSTB_png;
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateSearchCommand { get; }
        public ICommand NavigateCommand { get; }
        public NavigationBarViewModel()
        {
            // Initialize commands
            NavigateCommand = new RelayCommand(param =>
            {
                switch (param)
                {
                    case "Home":
                        NavigationHelper.Navigate(typeof(Home));
                        break;
                    case "Login":
                        NavigationHelper.Navigate(typeof(Login));
                        break;
                    case "Search":
                        NavigationHelper.Navigate(typeof(Search));
                        break;
                }
            });
        }
        private void NavigateHome()
        {
            NavigationHelper.NavigateTo(typeof(Home));
        }
        private void NavigateLogin()
        {
            if (LoginModel.Connected)
            {
                LoginModel.Connected = false;
                ServiceUser.LoginDetails.Clear();
                MessageBox.Show("Log out successfully!");
            }
            NavigationHelper.NavigateTo(typeof(Login));
        }
        private void NavigateSearch()
        {
            if (LoginModel.Connected)
            {
                NavigationHelper.NavigateTo(typeof(Search));
            }
            else
            {
                NavigationHelper.NavigateTo(typeof(Login));
            }
        }
    }
}
