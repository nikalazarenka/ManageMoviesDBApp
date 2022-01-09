using System.Collections.Generic;
using System.Linq;
using ManageMoviesDBApp.Model.Data;


namespace ManageMoviesDBApp.Model
{
    public static class DataWorker
    {
        public static string CreateCountry(string name)
        {
            string result = "Already exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool isExsists = db.Countries.Any(country => country.Name == name);
                if (!isExsists)
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
                bool isExsists = db.Genres.Any(genre => genre.Name == name);
                if (!isExsists)
                {
                    Genre newGenre = new Genre { Name = name };
                    db.Add(newGenre);
                    db.SaveChanges();
                    result = "It's done!";
                }
            }
            return result;
        }

        public static string CreateMovie(string name, List<Genre> genres, Studio studio, int year, double rating)
        {
            string result = "Already exsists!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool isExsists = db.Movies.Any(movie => movie.Name == name);
                if (!isExsists)
                {
                    Movie newMovie = new Movie
                    {
                        Name = name,
                        Genres = genres,
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
                bool isExsists = db.Studios.Any(studio => studio.Name == name);
                if (!isExsists)
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

        //delete country
        //public static string DeleteMovie(Movie movie)
        //{

        //}


        //delete genre

        //delete movie

        //delete studio

        //edit country

        //edit genre

        //edit movie

        //edit studio

    }
}
