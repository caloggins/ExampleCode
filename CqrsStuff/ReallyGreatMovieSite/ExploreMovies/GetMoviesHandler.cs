using System.Collections.Generic;
using System.Linq;
using MediatR;

// ReSharper disable UnusedMember.Global

namespace ReallyGreatMovieSite.ExploreMovies
{
    public class GetMoviesHandler : IRequestHandler<GetMovies, IEnumerable<Movie>>
    {
        private readonly MoviesDatabase database;

        public GetMoviesHandler(MoviesDatabase database)
        {
            this.database = database;
        }

        public IEnumerable<Movie> Handle(GetMovies message)
        {
            return database.Movies.ToList();
        }
    }
}