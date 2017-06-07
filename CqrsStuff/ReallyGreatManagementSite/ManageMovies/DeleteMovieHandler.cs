using System.Linq;
using MediatR;
using MemBus;
using MovieEvents;

// ReSharper disable UnusedMember.Global

namespace ReallyGreatManagementSite.ManageMovies
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovie, Unit>
    {
        private readonly MoviesDatabase database;
        private readonly IBus bus;

        public DeleteMovieHandler(MoviesDatabase database, IBus bus)
        {
            this.database = database;
            this.bus = bus;
        }

        public Unit Handle(DeleteMovie message)
        {
            var dead = database.Movies.First(movie => movie.Id == message.Id);
            database.Movies.Remove(dead);

            var movieDeleted = new MovieDeleted(message.Id);
            bus.Publish(movieDeleted);

            return new Unit();
        }
    }
}