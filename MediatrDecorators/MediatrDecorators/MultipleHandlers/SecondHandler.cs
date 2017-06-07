using MediatR;

namespace MediatrDecorators.MultipleHandlers
{
    public class SecondHandler : IRequestHandler<MultipleCommand, string>
    {
        public string Handle(MultipleCommand message)
        {
            return message.Name;
        }
    }
}