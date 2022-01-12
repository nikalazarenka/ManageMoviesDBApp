using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMoviesDBApp.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Studio> Studios { get; set; }
    }
}
