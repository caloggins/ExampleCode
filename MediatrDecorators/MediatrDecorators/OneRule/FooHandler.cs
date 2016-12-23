using MediatR;

// ReSharper disable UnusedMember.Global

namespace MediatrDecorators.OneRule
{
    public class FooHandler : IRequestHandler<Foo, Response>
    {
        public Response Handle(Foo message)
        {
            return new Response();
        }
    }
}