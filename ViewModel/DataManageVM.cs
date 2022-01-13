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

        #region PROPERTIES
        //properties for Country
        public static string CountryName { get; set; }

        //properties for Genre
        public static string GenreName { get; set; }

        //properties for Movie
        public static string MovieName { get; set; }
        public static Genre Genre { get; set; }
        public static Studio Studio { get; set; }
        public static int Year { get; set; }
        public static int Rating { get; set; }

        //properties for Studio
        public static string StudioName { get; set; }
        public static Country Country { get; set; }
        #endregion

        #region PROPERTIES FOR SELECTED ITEMS
        public TabItem SelectedTabItem { get; set; }
        public static Country SelectedCountry { get; set; }
        public static Genre SelectedGenre { get; set; }
        public static Movie SelectedMovie { get; set; }
        public static Studio SelectedStudio { get; set; }
        #endregion

        #region COMMANDS TO DELETE
        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "No items selected!";
                    //country
                    if (SelectedTabItem.Name == "CountryTab" && SelectedCountry != null)
                    {
                        resultStr = DataWorker.DeleteCountry(SelectedCountry);
                        UpdateAllViews();
                    }
                    //genre
                    if (SelectedTabItem.Name == "GenreTab" && SelectedGenre != null)
                    {
                        resultStr = DataWorker.DeleteGenre(SelectedGenre);
                        UpdateAllViews();
                    }
                    //movie
                    if (SelectedTabItem.Name == "MovieTab" && SelectedMovie != null)
                    {
                        resultStr = DataWorker.DeleteMovie(SelectedMovie);
                        UpdateAllViews();
                    }
                    //studio
                    if (SelectedTabItem.Name == "StudioTab" && SelectedStudio != null)
                    {
                        resultStr = DataWorker.DeleteStudio(SelectedStudio);
                        UpdateAllViews();
                    }
                    //update
                    SetNullValueToProperties();
                    ShowMessageToUser(resultStr);
                }
                );
            }
        }
        #endregion

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
                    if(CountryName is null || CountryName.Replace(" ", "").Length == 0)
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
                    if (GenreName is null || GenreName.Replace(" ", "").Length == 0)
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

        private RelayCommand addNewStudio;
        public RelayCommand AddNewStudio
        {
            get
            {
                return addNewStudio ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = string.Empty;
                    if (StudioName is null || StudioName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "StudioNameBlock");
                    }
                    if (Country is null)
                    {
                        MessageBox.Show("Choose a country!");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateStudio(StudioName, Country);
                        UpdateAllViews();
                        ShowMessageToUser(resultStr);
                        SetNullValueToProperties();
                        window.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewMovie;
        public RelayCommand AddNewMovie
        {
            get
            {
                return addNewStudio ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = string.Empty;
                    if (MovieName is null || MovieName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "MovieNameBlock");
                    }
                    if (Year==0 || Year>DateTime.Now.Year || Year < 1895)
                    {
                        SetRedBlockControl(window, "YearBlock");
                    }
                    if (Rating < 0 || Rating > 10)
                    {
                        SetRedBlockControl(window, "RatingBlock");
                    }
                    if (Studio is null)
                    {
                        MessageBox.Show("Choose a studio!");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateMovie(MovieName, Genre, Studio, Year, Rating);
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

        #region COMMANDS TO EDIT
        private RelayCommand editCountry;
        public RelayCommand EditCountry
        {
            get
            {
                return editCountry ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "No countries selected!";
                    if (SelectedCountry != null)
                    {
                        resultStr = DataWorker.EditCountry(SelectedCountry, CountryName);
                        UpdateAllViews();
                        SetNullValueToProperties();
                        ShowMessageToUser(resultStr);
                        window.Close();
                    }
                    else
                    {
                        ShowMessageToUser(resultStr);
                    }
                }
                );
            }
        }
        private RelayCommand editGenre;
        public RelayCommand EditGenre
        {
            get
            {
                return editGenre ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "No genres selected!";
                    if (SelectedGenre != null)
                    {
                        resultStr = DataWorker.EditGenre(SelectedGenre, GenreName);
                        UpdateAllViews();
                        SetNullValueToProperties();
                        ShowMessageToUser(resultStr);
                        window.Close();
                    }
                    else
                    {
                        ShowMessageToUser(resultStr);
                    }
                }
                );
            }
        }
        private RelayCommand editMovie;
        public RelayCommand EditMovie
        {
            get
            {
                return editMovie ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "No movies selected!";
                    if (SelectedMovie != null)
                    {
                        resultStr = DataWorker.EditMovie(SelectedMovie, MovieName,Genre,Studio,Year,Rating);
                        UpdateAllViews();
                        SetNullValueToProperties();
                        ShowMessageToUser(resultStr);
                        window.Close();
                    }
                    else
                    {
                        ShowMessageToUser(resultStr);
                    }
                }
                );
            }
        }
        private RelayCommand editStudio;
        public RelayCommand EditStudio
        {
            get
            {
                return editStudio ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "No studios selected!";
                    if (SelectedStudio != null)
                    {
                        resultStr = DataWorker.EditStudio(SelectedStudio, StudioName, Country);
                        UpdateAllViews();
                        SetNullValueToProperties();
                        ShowMessageToUser(resultStr);
                        window.Close();
                    }
                    else
                    {
                        ShowMessageToUser(resultStr);
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

        private RelayCommand openEditWindow;
        public RelayCommand OpenEditWindow
        {
            get
            {
                return openEditWindow ?? new RelayCommand(obj =>
                {
                    string resultStr = "No items selected!";
                    if (SelectedTabItem.Name == "CountryTab" && SelectedCountry != null)
                    {
                        OpenEditCountryWindowMethod(SelectedCountry);
                    }
                    else if (SelectedTabItem.Name == "GenreTab" && SelectedGenre != null)
                    {
                        OpenEditGenreWindowMethod(SelectedGenre);
                    }
                    else if (SelectedTabItem.Name == "MovieTab" && SelectedMovie != null)
                    {
                        OpenEditMovieWindowMethod(SelectedMovie);
                    }
                    else if (SelectedTabItem.Name == "StudioTab" && SelectedStudio != null)
                    {
                        OpenEditStudioWindowMethod(SelectedStudio);
                    }
                    else
                    {
                        ShowMessageToUser(resultStr);
                    }
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

        private void OpenEditCountryWindowMethod(Country country)
        {
            EditCountryWindow editCountryWindow = new EditCountryWindow(country);
            SetCenterPositionAndOpen(editCountryWindow);
        }

        private void OpenEditGenreWindowMethod(Genre genre)
        {
            EditGenreWindow editGenreWindow = new EditGenreWindow(genre);
            SetCenterPositionAndOpen(editGenreWindow);
        }

        private void OpenEditMovieWindowMethod(Movie movie)
        {
            EditMovieWindow editMovieWindow = new EditMovieWindow(movie);
            SetCenterPositionAndOpen(editMovieWindow);
        }

        private void OpenEditStudioWindowMethod(Studio studio)
        {
            EditStudioWindow editStudioWindow = new EditStudioWindow(studio);
            SetCenterPositionAndOpen(editStudioWindow);
        }
        private void ShowMessageToUser(string message)
        {
            MessageWindow messageWindow = new MessageWindow(message);
            SetCenterPositionAndOpen(messageWindow);
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
