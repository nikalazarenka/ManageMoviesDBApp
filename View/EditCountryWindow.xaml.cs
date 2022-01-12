using ManageMoviesDBApp.ViewModel;
using ManageMoviesDBApp.Model;
using System.Windows;

namespace ManageMoviesDBApp.View
{
    /// <summary>
    /// Interaction logic for EditCountryWindow.xaml
    /// </summary>
    public partial class EditCountryWindow : Window
    {
        public EditCountryWindow(Country countryToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedCountry = countryToEdit;
            DataManageVM.CountryName = countryToEdit.Name;
        }
    }
}
