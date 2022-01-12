using ManageMoviesDBApp.Model;
using ManageMoviesDBApp.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace ManageMoviesDBApp.View
{
    /// <summary>
    /// Interaction logic for EditMovieWindow.xaml
    /// </summary>
    public partial class EditMovieWindow : Window
    {
        public EditMovieWindow(Movie movieToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedMovie = movieToEdit;
            DataManageVM.MovieName = movieToEdit.Name;
            DataManageVM.Year = movieToEdit.Year;
            DataManageVM.Rating = movieToEdit.Rating;
            DataManageVM.Studio = movieToEdit.Studio;
            DataManageVM.Genre = movieToEdit.Genre;

        }
        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
