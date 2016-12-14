using MediatR;

namespace MediatrDecorators.MultipleRules
{
    public class Bar : IRequest<Response>
    {
        public string Message { get; set; }
        public string Author { get; set; }
    }
}