using System;

// ReSharper disable UnusedMember.Global

namespace MovieEvents
{
    public class MovieDeleted
    {
        public MovieDeleted(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}