using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfApp.Components;
using WpfApp.Model;
using WpfApp.ViewModels;

namespace WpfApp
{
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
            this.DataContext = new SearchViewModel();
        }
        
    }
}
