// ReSharper disable UnusedMember.Global

using MediatR;

namespace ReallyGreatManagementSite.ManageMovies
{
    public class ManageApi
    {
        private readonly IMediator mediator;

        public ManageApi(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void AddMovie(string title)
        {
            var addMovie = new AddMovie(title);
            mediator.Send(addMovie);
        }

        public void DeleteMovie(Movie movie)
        {
            var deleteMovie = new DeleteMovie(movie.Id);
            mediator.Send(deleteMovie);
        }
    }
}