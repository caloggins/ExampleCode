using MediatR;

namespace MediatrDecorators.OneRule
{
    public class Foo : IRequest<Response>
    {
        public string Message { get; set; }
    }
}