using ManageMoviesDBApp.ViewModel;
using System.Windows;

namespace ManageMoviesDBApp.View
{
    /// <summary>
    /// Interaction logic for AddNewGenreWindow.xaml
    /// </summary>
    public partial class AddNewGenreWindow : Window
    {
        public AddNewGenreWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
