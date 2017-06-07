using System;

namespace GreatMovieSite.MovieManagement
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
    }
}