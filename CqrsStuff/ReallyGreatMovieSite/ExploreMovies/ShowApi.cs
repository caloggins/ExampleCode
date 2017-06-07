using System.Collections.Generic;
using MediatR;

// ReSharper disable UnusedMember.Global

namespace ReallyGreatMovieSite.ExploreMovies
{
    public class ShowApi
    {
        private readonly IMediator mediator;

        public ShowApi(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IEnumerable<Movie> GetMovies()
        {
            var getMovies = new GetMovies();
            return mediator.Send(getMovies);
        }

        public IEnumerable<Movie> GetFavorites()
        {
            var getFavorites = new GetFavorites();
            return mediator.Send(getFavorites);
        }
    }
}