using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
