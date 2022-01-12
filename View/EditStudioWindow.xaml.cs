using ManageMoviesDBApp.Model;
using ManageMoviesDBApp.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace ManageMoviesDBApp.View
{
    /// <summary>
    /// Interaction logic for EditStudioWindow.xaml
    /// </summary>
    public partial class EditStudioWindow : Window
    {
        public EditStudioWindow(Studio studioToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedStudio = studioToEdit;
            DataManageVM.StudioName = studioToEdit.Name;
            DataManageVM.Country = studioToEdit.Country;
        }
        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
