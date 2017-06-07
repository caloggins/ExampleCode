using System;
using MemBus;
using MovieEvents;

namespace MoveEventProcessor
{
    public class AddedListener : IListener
    {
        private readonly IBus bus;
        private readonly MoviesDatabase database;

        public AddedListener(IBus bus, MoviesDatabase database)
        {
            this.bus = bus;
            this.database = database;
        }

        public void Start()
        {
            bus.Subscribe<MovieAdded>(added =>
            {
                var movie = new Movie
                {
                    Id = Guid.NewGuid(),
                    MovieId = added.Id,
                    Title = added.Title,
                    AverageRating = 0
                };
                database.Movies.Add(movie);
            });
        }
    }
}