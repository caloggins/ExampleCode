using System;
using MediatR;
using MemBus;
using MovieEvents;

namespace ReallyGreatManagementSite.ManageMovies
{
    public class AddMovieHandler : IRequestHandler<AddMovie, Unit>
    {
        private readonly MoviesDatabase database;
        private readonly IBus bus;

        public AddMovieHandler(MoviesDatabase database, IBus bus)
        {
            this.database = database;
            this.bus = bus;
        }

        public Unit Handle(AddMovie message)
        {
            var id = Guid.NewGuid();

            var movie = new Movie
            {
                Id = id,
                Title = message.Title
            };
            database.Movies.Add(movie);

            var movieAdded = new MovieAdded(id, message.Title);
            bus.Publish(movieAdded);

            return new Unit();
        }
    }
}