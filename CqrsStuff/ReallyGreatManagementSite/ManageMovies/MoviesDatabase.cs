using System.Collections.Generic;

namespace ReallyGreatManagementSite.ManageMovies
{
    public class MoviesDatabase
    {
        public readonly IList<Movie> Movies = new List<Movie>();
    }
}