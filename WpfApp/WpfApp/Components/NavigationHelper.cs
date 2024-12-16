using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Components
{
    public class NavigationHelper
    {
        public static void NavigateTo(Type pageType)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            if (mainWindow.MainContent.Content?.GetType() == pageType)
            {
                return; // Page is already displayed
            }

            if (Activator.CreateInstance(pageType) is UserControl pageInstance)
            {
                mainWindow.MainContent.Content = pageInstance;
            }
            else
            {
                throw new InvalidOperationException("Navigation target must be a UserControl.");
            }
        }
    }
}
