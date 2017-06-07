using MediatR;

namespace ReallyGreatManagementSite.ManageMovies
{
    public class AddMovie : IRequest<Unit>
    {
        public AddMovie(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}