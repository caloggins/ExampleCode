using System;
using MediatR;

namespace ReallyGreatManagementSite.RateMovies
{
    public class AddRating : IRequest<Unit>
    {
        public Guid Id { get; }
        public int Score { get; }

        public AddRating(Guid id, int score)
        {
            Id = id;
            Score = score;
        }
    }
}