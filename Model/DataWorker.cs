using System.Collections.Generic;
using System.Linq;
using ManageMoviesDBApp.Model.Data;


namespace ManageMoviesDBApp.Model
{
    public static class DataWorker
    {
        public static List<Country> GetAllCountries()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.Countries.ToList();
            }
        }

        public static List<Genre> GetAllGenres()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Genres.ToList();
            }
        }

        public static List<Movie> GetAllMovies()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Movies.ToList();
            }
        }

        public static List<Studio> GetAllStudios()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Studios.ToList();
            }
        }
        public static string CreateCountry(string name)
        {
            string result = "Already exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Countries.Any(country => country.Name == name))
                {
                    Country newCountry = new Country { Name = name };
                    db.Add(newCountry);
                    db.SaveChanges();
                    result = "It's done!";
                }
            }
            return result;
        }

        public static string CreateGenre(string name)
        {
            string result = "Already exsists!";
            using(ApplicationContext db = new ApplicationContext())
            {
                if (!db.Genres.Any(genre => genre.Name == name))
                {
                    Genre newGenre = new Genre { Name = name };
                    db.Add(newGenre);
                    db.SaveChanges();
                    result = "It's done!";
                }
            }
            return result;
        }

        public static string CreateMovie(string name, Genre genre, Studio studio, int year, int rating)
        {
            string result = "Already exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Movies.Any(movie => movie.Name == name))
                {
                    Movie newMovie = new Movie
                    {
                        Name = name,
                        GenreId = genre.Id,
                        StudioId = studio.Id,
                        Year = year,
                        Rating = rating
                    };

                    db.Add(newMovie);
                    db.SaveChanges();
                    result = "It's done!";
                }
            }
            return result;
        }

        public static string CreateStudio(string name, Country country)
        {
            string result = "Already exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Studios.Any(studio => studio.Name == name))
                {
                    Studio newStudio = new Studio 
                    {
                        Name = name,
                        CountryId = country.Id
                    };

                    db.Add(newStudio);
                    db.SaveChanges();
                    result = "It's done!";
                }
            }

            return result;
        }

        public static string DeleteCountry(Country country)
        {
            string result = "Not exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Countries.Remove(country);
                db.SaveChanges();
                result = "It's done! " + country.Name + " was deleted.";
            }

            return result;
        }


        public static string DeleteGenre(Genre genre)
        {
            string result = "Not exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Genres.Remove(genre);
                db.SaveChanges();
                result = "It's done! " + genre.Name + " was deleted.";
            }

            return result;
        }

        public static string DeleteMovie(Movie movie)
        {
            string result = "Not exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
                result = "It's done! " + movie.Name + " was deleted.";
            }

            return result;
        }

        public static string DeleteStudio(Studio studio)
        {
            string result = "Not exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Studios.Remove(studio);
                db.SaveChanges();
                result = "It's done! " + studio.Name + " was deleted.";
            }

            return result;
        }

        public static string EditCountry(Country oldCountry, string newName)
        {
            string result = "Not exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                Country country = db.Countries.FirstOrDefault(c => c.Id == oldCountry.Id);
                country.Name = newName;
                db.SaveChanges();
                result = "It's done!";
            }

            return result;
        }

        public static string EditGenre(Genre oldGenre, string newName)
        {
            string result = "Not exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                Genre genre = db.Genres.FirstOrDefault(g => g.Id == oldGenre.Id);
                genre.Name = newName;
                db.SaveChanges();
                result = "It's done!";
            }

            return result;
        }

        public static string EditMovie(Movie oldMovie, string newName, Genre newGenre, Studio newStudio, int newYear, int newRating)
        {
            string result = "Not exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                Movie movie = db.Movies.FirstOrDefault(m => m.Id == oldMovie.Id);
                movie.Name = newName;
                movie.GenreId = newGenre.Id;
                movie.StudioId = newStudio.Id;
                movie.Year = newYear;
                movie.Rating = newRating;
                db.SaveChanges();
                result = "It's done!";
            }

            return result;
        }

        public static string EditStudio(Studio oldStudio, string newName, Country newCountry)
        {
            string result = "Not exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                Studio studio = db.Studios.FirstOrDefault(s => s.Id == oldStudio.Id);
                studio.Name = newName;
                studio.CountryId = newCountry.Id;
                db.SaveChanges();
                result = "It's done!";
            }

            return result;
        }

        public static Country GetCountryById(int id)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Country country = db.Countries.FirstOrDefault(c => c.Id == id);
                return country;
            }
        }
        public static Studio GetStudioById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Studio studio = db.Studios.FirstOrDefault(s => s.Id == id);
                return studio;
            }
        }
        public static Genre GetGenreById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Genre genre = db.Genres.FirstOrDefault(g => g.Id == id);
                return genre;
            }
        }
    }
}
