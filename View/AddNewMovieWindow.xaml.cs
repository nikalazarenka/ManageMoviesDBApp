using ManageMoviesDBApp.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace ManageMoviesDBApp.View
{
    /// <summary>
    /// Interaction logic for AddNewMovieWindow.xaml
    /// </summary>
    public partial class AddNewMovieWindow : Window
    {
        public AddNewMovieWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
