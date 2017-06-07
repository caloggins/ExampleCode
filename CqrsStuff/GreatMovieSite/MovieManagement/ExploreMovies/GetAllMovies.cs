using System.Collections.Generic;
using MediatR;

namespace GreatMovieSite.MovieManagement.ExploreMovies
{
    public class GetAllMovies : IRequest<IEnumerable<Movie>>
    {
    }
}