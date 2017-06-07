using MediatR;

namespace GreatMovieSite.MovieManagement.EditMovieLists
{
    public class AddMovie : IRequest
    {

        public AddMovie(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}