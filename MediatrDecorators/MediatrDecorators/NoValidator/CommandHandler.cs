using MediatR;

namespace MediatrDecorators.NoValidator
{
    // ReSharper disable once UnusedMember.Global
    public class CommandHandler : IRequestHandler<Command, Response>
    {
        public Response Handle(Command message)
        {
            return new Response();
        }
    }
}