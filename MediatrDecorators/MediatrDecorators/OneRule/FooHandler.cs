using System.Threading;
using System.Threading.Tasks;
using MediatR;

// ReSharper disable UnusedMember.Global

namespace MediatrDecorators.OneRule
{
    public class FooHandler : IRequestHandler<Foo, Response>
    {
        public Task<Response> Handle(Foo message, CancellationToken token)
        {
            return Task.FromResult(new Response());
        }
    }
}