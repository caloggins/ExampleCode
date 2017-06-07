using System.Collections.Generic;
using MediatR;

namespace GreatMovieSite.MovieManagement.EditMovieLists
{
    public class DeleteMovie : IRequest
    {

        public DeleteMovie(Movie movie)
        {
            Movie = movie;
        }

        public Movie Movie { get; }
    }
}