using System;

namespace ReallyGreatManagementSite.RateMovies
{
    public class Rating
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public int Score { get; set; }
    }
}