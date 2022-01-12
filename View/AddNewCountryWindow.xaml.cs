using ManageMoviesDBApp.ViewModel;
using System.Windows;


namespace ManageMoviesDBApp.View
{
    /// <summary>
    /// Interaction logic for AddNewCountryWindow.xaml
    /// </summary>
    public partial class AddNewCountryWindow : Window
    {
        public AddNewCountryWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
