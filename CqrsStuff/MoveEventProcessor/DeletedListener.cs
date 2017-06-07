using System.Linq;
using MemBus;
using MovieEvents;

namespace MoveEventProcessor
{
    // ReSharper disable once UnusedMember.Global
    public class DeletedListener : IListener
    {
        private readonly IBus bus;
        private readonly MoviesDatabase database;

        public DeletedListener(IBus bus, MoviesDatabase database)
        {
            this.bus = bus;
            this.database = database;
        }

        public void Start()
        {
            bus.Subscribe<MovieDeleted>(deleted =>
            {
                var dead = database.Movies.First(movie => movie.MovieId == deleted.Id);
                database.Movies.Remove(dead);
            });
        }
    }
}