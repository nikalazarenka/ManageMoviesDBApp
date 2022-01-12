using ManageMoviesDBApp.ViewModel;
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
    }
}
