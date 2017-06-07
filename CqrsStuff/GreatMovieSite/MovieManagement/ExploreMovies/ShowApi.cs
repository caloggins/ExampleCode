using System.Collections.Generic;
using GreatMovieSite.Database;

namespace GreatMovieSite.MovieManagement.ExploreMovies
{
    public class ShowApi
    {
        private readonly IStoreMovies database;

        public ShowApi(IStoreMovies database)
        {
            this.database = database;
        }

        public IEnumerable<Movie> GetMovies()
        {
            var getAllMovies = new GetAllMovies();
            return getAllMovies.Query(database.Movies);
        }

        public IEnumerable<Movie> GetRatedMovies(int rating)
        {
            var getRatedMovies = new GetRatedMovies(rating);
            return getRatedMovies.Query(database.Movies);
        }
    }
}