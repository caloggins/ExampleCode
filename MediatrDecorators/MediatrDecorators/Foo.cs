using MediatR;

namespace MediatrDecorators
{
    public class Foo : IRequest<Response>
    {
        public string Message { get; set; }
    }
}