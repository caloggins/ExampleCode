using MediatR;
// ReSharper disable UnusedMember.Global

namespace MediatrDecorators
{
    public class FooHandler : IRequestHandler<Foo, Response>
    {
        public Response Handle(Foo message)
        {
            return new Response();
        }
    }
}