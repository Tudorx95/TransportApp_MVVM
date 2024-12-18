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

namespace WpfApp.ViewModels
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
                if (param is string target)
                {
                    switch (target)
                    {
                        case "Home":
                            NavigateHome(typeof(Home));
                            break;
                        case "Login":
                            HandleLoginNavigation();
                            break;
                        case "Search":
                            HandleSearchNavigation();
                            break;
                    }
                }
            });
        }
        private void HandleLoginNavigation()
        {
            if (LoginModel.Connected)
            {
                LoginModel.Connected = false;
                ServiceUser.LoginDetails.Clear();
                System.Windows.MessageBox.Show("Log out successfully!");
            }
            NavigationHelper.NavigateTo(typeof(Login));
        }
        private void HandleSearchNavigation()
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

        private void NavigateHome(Type pageType)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow?.MainContent.Content?.GetType() == pageType)
            {
                // If the requested page is already displayed, do nothing
                return;
            }
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
