using System.Collections.Generic;
using System.Linq;
using GreatMovieSite.MovieManagement;
using GreatMovieSite.MovieManagement.ExploreMovies;
using MediatR;

namespace GreatMovieSite.Database
{
    public class GetAllMoviesHandler : IRequestHandler<GetAllMovies, IEnumerable<Movie>>
    {
        private readonly MovieDatabase database;

        public GetAllMoviesHandler(MovieDatabase database)
        {
            this.database = database;
        }

        public IEnumerable<Movie> Handle(GetAllMovies message)
        {
            return database.Set<Movie>().ToList();
        }
    }
}