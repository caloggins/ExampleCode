using System.Collections.Generic;
using MediatR;

namespace ReallyGreatMovieSite.ExploreMovies
{
    public class GetFavorites : IRequest<IEnumerable<Movie>>
    {
        
    }
}