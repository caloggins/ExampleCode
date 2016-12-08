using MediatR;

namespace MediatrDecorators
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