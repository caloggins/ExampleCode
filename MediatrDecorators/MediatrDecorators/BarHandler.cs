using MediatR;
// ReSharper disable UnusedMember.Global

namespace MediatrDecorators
{
    public class BarHandler : IRequestHandler<Bar, Response>
    {
        public Response Handle(Bar message)
        {
            return new Response();
        }
    }
}