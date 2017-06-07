using System.Collections.Generic;
using System.Linq;
using GreatMovieSite.MovieManagement;
using GreatMovieSite.MovieManagement.ExploreMovies;
using MediatR;

namespace GreatMovieSite.Database
{
    public class GetRatedMoviesHandler : IRequestHandler<GetRatedMovies, IEnumerable<Movie>>
    {
        private readonly MovieDatabase database;

        public GetRatedMoviesHandler(MovieDatabase database)
        {
            this.database = database;
        }

        public IEnumerable<Movie> Handle(GetRatedMovies message)
        {
            return database.Set<Movie>()
                .Where(_ => _.Rating >= message.MinimumRating)
                .ToList();
        }
    }
}