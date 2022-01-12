using ManageMoviesDBApp.Model;
using ManageMoviesDBApp.ViewModel;
using System.Windows;

namespace ManageMoviesDBApp.View
{
    /// <summary>
    /// Interaction logic for EditGenreWindow.xaml
    /// </summary>
    public partial class EditGenreWindow : Window
    {
        public EditGenreWindow(Genre genreToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedGenre = genreToEdit;
            DataManageVM.GenreName = genreToEdit.Name;

        }
    }
}
