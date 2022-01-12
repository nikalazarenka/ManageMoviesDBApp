using System.ComponentModel.DataAnnotations.Schema;

namespace ManageMoviesDBApp.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
        public int StudioId { get; set; }
        public virtual Studio Studio { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        [NotMapped]
        public Studio MovieStudio
        {
            get
            {
                return DataWorker.GetStudioById(StudioId);
            }
        }

        [NotMapped]
        public Genre MovieGenre
        {
            get
            {
                return DataWorker.GetGenreById(GenreId);
            }
        }
    }
}
