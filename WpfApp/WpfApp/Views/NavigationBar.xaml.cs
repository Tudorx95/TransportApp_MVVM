using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Components;
using WpfApp.ViewModels;

namespace WpfApp
{
    public partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            InitializeComponent();
            DataContext = new NavigationBarViewModel();
        }

    }
}
