using MediatR;

namespace MediatrDecorators
{
    public class Bar : IRequest<Response>
    {
        public string Message { get; set; }
        public string Author { get; set; }
    }
}