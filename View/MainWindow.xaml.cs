using ManageMoviesDBApp.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ManageMoviesDBApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllCountriesView;
        public static ListView AllGenresView;
        public static ListView AllStudiosView;
        public static ListView AllMoviesView;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            AllCountriesView = ViewAllCountries;
            AllGenresView = ViewAllGenres;
            AllStudiosView = ViewAllStudios;
            AllMoviesView = ViewAllMovies;
        }
    }
}
