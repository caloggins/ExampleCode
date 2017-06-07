using System;

namespace MoveEventProcessor
{
    public class Movie
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public string Title { get; set; }
        public int AverageRating { get; set; }
    }
}