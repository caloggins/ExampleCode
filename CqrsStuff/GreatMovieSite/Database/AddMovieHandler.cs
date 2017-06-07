using System;
using GreatMovieSite.MovieManagement;
using GreatMovieSite.MovieManagement.EditMovieLists;
using MediatR;

namespace GreatMovieSite.Database
{
    public class AddMovieHandler : IRequestHandler<AddMovie>
    {
        private readonly MovieDatabase database;

        public AddMovieHandler(MovieDatabase database)
        {
            this.database = database;
        }

        public void Handle(AddMovie message)
        {
            if(string.IsNullOrWhiteSpace(message.Title))
                throw new ArgumentException();

            var movie = new Movie
            {
                Id = Guid.NewGuid(),
                Rating = 5,
                Title = message.Title
            };
            database.Set<Movie>().Add(movie);
            database.SaveChanges();
        }
    }
}