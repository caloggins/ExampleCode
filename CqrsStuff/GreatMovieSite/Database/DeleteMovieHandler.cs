using GreatMovieSite.MovieManagement;
using GreatMovieSite.MovieManagement.EditMovieLists;
using MediatR;

namespace GreatMovieSite.Database
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovie>
    {
        private readonly MovieDatabase database;

        public DeleteMovieHandler(MovieDatabase database)
        {
            this.database = database;
        }

        public void Handle(DeleteMovie message)
        {
            database.Set<Movie>().Remove(message.Movie);
            database.SaveChanges();
        }
    }
}