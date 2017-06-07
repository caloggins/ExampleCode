using System;
using System.Linq;
using MediatR;
using MemBus;
using MovieEvents;

// ReSharper disable UnusedMember.Global

namespace ReallyGreatManagementSite.RateMovies
{
    public class AddRatingHandler : IRequestHandler<AddRating, Unit>
    {
        private readonly RatingsDatabase database;
        private readonly IBus bus;

        public AddRatingHandler(RatingsDatabase database, IBus bus)
        {
            this.database = database;
            this.bus = bus;
        }

        public Unit Handle(AddRating message)
        {
            var rating = new Rating
            {
                Id = Guid.NewGuid(),
                MovieId = message.Id,
                Score = message.Score,
            };
            database.Ratings.Add(rating);

            var score = (int)database.Ratings.Average(r => r.Score);
            var movieRated = new MovieRated(message.Id, score);
            bus.Publish(movieRated);

            return new Unit();
        }
    }
}