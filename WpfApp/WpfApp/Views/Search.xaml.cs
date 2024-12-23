using System.Windows.Controls;
using WpfApp.ViewModel;

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