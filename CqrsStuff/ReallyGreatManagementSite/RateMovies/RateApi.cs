using System;
using MediatR;

// ReSharper disable UnusedMember.Global

namespace ReallyGreatManagementSite.RateMovies
{
    public class RateApi
    {
        private readonly IMediator mediator;

        public RateApi(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void RateMovie(Guid id, int score)
        {
            var addRating = new AddRating(id, score);
            mediator.Send(addRating);
        }
    }
}