using System.Collections.Generic;
using System.Linq;
using MediatR;

// ReSharper disable UnusedMember.Global

namespace ReallyGreatMovieSite.ExploreMovies
{
    public class GetFavoritesHandler : IRequestHandler<GetFavorites, IEnumerable<Movie>>
    {
        private const int FavoritesRatingThreshold = 5;
        private readonly MoviesDatabase database;

        public GetFavoritesHandler(MoviesDatabase database)
        {
            this.database = database;
        }

        public IEnumerable<Movie> Handle(GetFavorites message)
        {
            return database.Movies.Where(movie => movie.AverageRating >= FavoritesRatingThreshold)
                .ToList();
        }
    }
}