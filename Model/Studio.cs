using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageMoviesDBApp.Model
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public List<Movie> Movies { get; set; }

        [NotMapped]
        public Country StudioCountry
        {
            get
            {
                return DataWorker.GetCountryById(CountryId);
            }
        }
    }
}
