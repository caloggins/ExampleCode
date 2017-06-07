using System;

// ReSharper disable UnusedMember.Global

namespace MovieEvents
{
    public class MovieAdded
    {
        public MovieAdded(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public Guid Id { get; }
        public string Title { get; }
    }
}