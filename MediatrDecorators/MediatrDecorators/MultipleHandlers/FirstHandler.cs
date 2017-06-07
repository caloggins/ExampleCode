using MediatR;

namespace MediatrDecorators.MultipleHandlers
{
    public class FirstHandler : IRequestHandler<MultipleCommand, string>
    {
        private readonly IRequestHandler<MultipleCommand, string> handler;

        public FirstHandler(IRequestHandler<MultipleCommand, string> handler)
        {
            this.handler = handler;
        }

        public string Handle(MultipleCommand message)
        {
            return handler.Handle(message);
        }
    }
}