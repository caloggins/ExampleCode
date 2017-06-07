using MediatR;

namespace MediatrDecorators.MultipleHandlers
{
    public class MultipleCommand : IRequest<string>
    {
        public string Name { get; set; }
    }
}