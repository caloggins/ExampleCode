using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace GreatMovieSite.MovieManagement.ExploreMovies
{
    public class GetRatedMovies : IRequest<IEnumerable<Movie>>
    {

        public GetRatedMovies(int minimumRating)
        {
            MinimumRating = minimumRating;
        }

        public readonly int MinimumRating;

    }
}