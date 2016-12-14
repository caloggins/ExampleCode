using MediatR;

namespace MediatrDecorators
{
    public class FizzHandler : IRequestHandler<Fizz, Response>
    {
        public Response Handle(Fizz message)
        {
            return new Response();
        }
    }
}