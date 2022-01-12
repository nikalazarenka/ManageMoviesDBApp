using ManageMoviesDBApp.ViewModel;
using System.Windows;

namespace ManageMoviesDBApp.View
{
    /// <summary>
    /// Interaction logic for AddNewStudioWindow.xaml
    /// </summary>
    public partial class AddNewStudioWindow : Window
    {
        public AddNewStudioWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
