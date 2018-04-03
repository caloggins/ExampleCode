using System.Threading;
using System.Threading.Tasks;
using MediatR;

// ReSharper disable UnusedMember.Global

namespace MediatrDecorators.MultipleRules
{
    public class BarHandler : IRequestHandler<Bar, Response>
    {
        public Task<Response> Handle(Bar message, CancellationToken token)
        {
            return Task.FromResult(new Response());
        }
    }
}