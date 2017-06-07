using System.Collections.Generic;
using MediatR;

namespace ReallyGreatMovieSite.ExploreMovies
{
    public class GetMovies : IRequest<IEnumerable<Movie>>
    {
        
    }
}