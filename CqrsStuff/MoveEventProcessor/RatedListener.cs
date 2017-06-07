using System.Linq;
using MemBus;
using MovieEvents;

namespace MoveEventProcessor
{
    public class RatedListener : IListener
    {
        private readonly IBus bus;
        private readonly MoviesDatabase database;

        public RatedListener(IBus bus, MoviesDatabase database)
        {
            this.bus = bus;
            this.database = database;
        }

        public void Start()
        {
            bus.Subscribe<MovieRated>(rated =>
            {
                var movie = database.Movies.First(m => m.MovieId == rated.Id);
                movie.AverageRating = rated.Score;
            });
        }
    }
}