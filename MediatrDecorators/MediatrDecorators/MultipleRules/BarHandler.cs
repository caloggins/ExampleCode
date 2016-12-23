using MediatR;

// ReSharper disable UnusedMember.Global

namespace MediatrDecorators.MultipleRules
{
    public class BarHandler : IRequestHandler<Bar, Response>
    {
        public Response Handle(Bar message)
        {
            return new Response();
        }
    }
}