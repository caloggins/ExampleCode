using System;

// ReSharper disable UnusedMember.Global

namespace MovieEvents
{
    public class MovieRated
    {
        public MovieRated(Guid id, int score)
        {
            Id = id;
            Score = score;
        }

        public int Score { get; }
        public Guid Id { get; }
    }
}