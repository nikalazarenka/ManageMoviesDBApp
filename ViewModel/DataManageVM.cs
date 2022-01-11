using ManageMoviesDBApp.Model;
using ManageMoviesDBApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        //properties for Country
        public string CountryName { get; set; }

        //properties for Genre
        public string GenreName { get; set; }

        //properties for Movie
        public string MovieName { get; set; }
        public List<Genre> Genres { get; set; }
        public Studio Studio { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }

        //properties for Studio
        public string StudioName { get; set; }
        public Country Country { get; set; }

        #region COMMANDS TO ADD
        private RelayCommand addNewCountry;
        public RelayCommand AddNewCountry
        {
            get
            {
                return addNewCountry ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = string.Empty;
                    if(string.IsNullOrWhiteSpace(CountryName))
                    {
                        SetRedBlockControl(window, "CountryNameBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateCountry(CountryName);
                        UpdateAllViews();
                        ShowMessageToUser(resultStr);
                        SetNullValueToProperties();
                        window.Close();
                    }
                }
                );
            }
        }

        private RelayCommand addNewGenre;
        public RelayCommand AddNewGenre
        {
            get
            {
                return addNewGenre ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = string.Empty;
                    if (string.IsNullOrWhiteSpace(GenreName))
                    {
                        SetRedBlockControl(window, "GenreNameBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateGenre(GenreName);
                        UpdateAllViews();
                        ShowMessageToUser(resultStr);
                        SetNullValueToProperties();
                        window.Close();
                    }
                }
                );
            }
        }
        #endregion

        #region COMMANDS TO OPEN WINDOWS
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

        #region UPDATE VIEWS
        private void SetNullValueToProperties()
        {
            CountryName = null;
            GenreName = null;
        }

        private void UpdateAllViews()
        {
            UpdateAllCountriesView();
            UpdateAllGenresView();
            UpdateAllMoviesView();
            UpdateAllStudiosView();
        }
        
        private void UpdateAllCountriesView()
        {
            AllCountries = DataWorker.GetAllCountries();
            MainWindow.AllCountriesView.ItemsSource = null;
            MainWindow.AllCountriesView.Items.Clear();
            MainWindow.AllCountriesView.ItemsSource = AllCountries;
            MainWindow.AllCountriesView.Items.Refresh();
        }
        private void UpdateAllGenresView()
        {
            AllGenres = DataWorker.GetAllGenres();
            MainWindow.AllGenresView.ItemsSource = null;
            MainWindow.AllGenresView.Items.Clear();
            MainWindow.AllGenresView.ItemsSource = AllGenres;
            MainWindow.AllGenresView.Items.Refresh();
        }
        private void UpdateAllMoviesView()
        {
            AllMovies = DataWorker.GetAllMovies();
            MainWindow.AllMoviesView.ItemsSource = null;
            MainWindow.AllMoviesView.Items.Clear();
            MainWindow.AllMoviesView.ItemsSource = AllMovies;
            MainWindow.AllMoviesView.Items.Refresh();
        }
        private void UpdateAllStudiosView()
        {
            AllStudios = DataWorker.GetAllStudios();
            MainWindow.AllStudiosView.ItemsSource = null;
            MainWindow.AllStudiosView.Items.Clear();
            MainWindow.AllStudiosView.ItemsSource = AllStudios;
            MainWindow.AllStudiosView.Items.Refresh();
        }
        #endregion

        private void SetRedBlockControl(Window window, string blockName)
        {
            Control block = window.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        private void ShowMessageToUser(string message)
        {
            MessageWindow messageWindow = new MessageWindow(message);
            SetCenterPositionAndOpen(messageWindow);
        }

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
