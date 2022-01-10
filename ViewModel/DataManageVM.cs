using ManageMoviesDBApp.Model;
using ManageMoviesDBApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace ManageMoviesDBApp.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        private List<Country> allCountries = DataWorker.GetAllCountries();
        public List<Country> AllCountries
        {
            get
            {
                return allCountries;
            }

            private set
            {
                allCountries = value;
            }
        }

        private List<Genre> allGenres = DataWorker.GetAllGenres();
        public List<Genre> AllGenres
        {
            get
            {
                return allGenres;
            }

            private set
            {
                allGenres = value;
            }
        }

        private List<Movie> allMovies = DataWorker.GetAllMovies();
        public List<Movie> AllMovies
        {
            get
            {
                return allMovies;
            }

            private set
            {
                allMovies = value;
            }
        }

        private List<Studio> allStudios = DataWorker.GetAllStudios();
        public List<Studio> AllStudios
        {
            get
            {
                return allStudios;
            }

            private set
            {
                allStudios = value;
            }
        }

        #region COMMANDS TO OPEN WONDOWS
        private RelayCommand openAddNewCountryWindow;
        public RelayCommand OpenAddNewCountryWindow
        {
            get
            {
                return openAddNewCountryWindow ?? new RelayCommand(obj =>
                {
                    OpenAddNewCountryWindowMethod();
                }
                );
            }
        }

        private RelayCommand openAddNewGenreWindow;
        public RelayCommand OpenAddNewGenreWindow
        {
            get
            {
                return openAddNewGenreWindow ?? new RelayCommand(obj =>
                {
                    OpenAddNewGenreWindowMethod();
                }
                );
            }
        }

        private RelayCommand openAddNewMovieWindow;
        public RelayCommand OpenAddNewMovieWindow
        {
            get
            {
                return openAddNewMovieWindow ?? new RelayCommand(obj =>
                {
                    OpenAddNewMovieWindowMethod();
                }
                );
            }
        }

        private RelayCommand openAddNewStudioWindow;
        public RelayCommand OpenAddNewStudioWindow
        {
            get
            {
                return openAddNewStudioWindow ?? new RelayCommand(obj =>
                {
                    OpenAddNewStudioWindowMethod();
                }
                );
            }
        }
        #endregion

        #region METHODS TO OPEN WINDOWS
        private void OpenAddNewCountryWindowMethod()
        {
            AddNewCountryWindow addNewCountryWindow = new AddNewCountryWindow();
            SetCenterPositionAndOpen(addNewCountryWindow);
        }

        private void OpenAddNewGenreWindowMethod()
        {
            AddNewGenreWindow addNewGenreWindow = new AddNewGenreWindow();
            SetCenterPositionAndOpen(addNewGenreWindow);
        }

        private void OpenAddNewMovieWindowMethod()
        {
            AddNewMovieWindow addNewMovieWindow = new AddNewMovieWindow();
            SetCenterPositionAndOpen(addNewMovieWindow);
        }

        private void OpenAddNewStudioWindowMethod()
        {
            AddNewStudioWindow addNewStudioWindow = new AddNewStudioWindow();
            SetCenterPositionAndOpen(addNewStudioWindow);
        }

        private void OpenEditCountryWindowMethod()
        {
            EditCountryWindow editCountryWindow = new EditCountryWindow();
            SetCenterPositionAndOpen(editCountryWindow);
        }

        private void OpenEditGenreWindowMethod()
        {
            EditGenreWindow editGenreWindow = new EditGenreWindow();
            SetCenterPositionAndOpen(editGenreWindow);
        }

        private void OpenEditMovieWindowMethod()
        {
            EditMovieWindow editMovieWindow = new EditMovieWindow();
            SetCenterPositionAndOpen(editMovieWindow);
        }

        private void OpenEditStudioWindowMethod()
        {
            EditStudioWindow editStudioWindow = new EditStudioWindow();
            SetCenterPositionAndOpen(editStudioWindow);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
