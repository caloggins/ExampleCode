using System;
using MediatR;

namespace ReallyGreatManagementSite.ManageMovies
{
    public class DeleteMovie : IRequest<Unit>
    {
        public DeleteMovie(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}