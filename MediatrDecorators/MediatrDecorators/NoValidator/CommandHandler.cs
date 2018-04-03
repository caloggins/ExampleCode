using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatrDecorators.NoValidator
{
    // ReSharper disable once UnusedMember.Global
    public class CommandHandler : IRequestHandler<Command, Response>
    {
        public Task<Response> Handle(Command message, CancellationToken token)
        {
            return Task.FromResult(new Response());
        }
    }
}