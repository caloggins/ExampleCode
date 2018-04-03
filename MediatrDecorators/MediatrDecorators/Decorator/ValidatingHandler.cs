using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace MediatrDecorators.Decorator
{
    public class ValidatingHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> handler;
        private readonly IValidator<TRequest> validator;

        public ValidatingHandler(IRequestHandler<TRequest, TResponse> handler, IValidator<TRequest> validator)
        {
            this.handler = handler;
            this.validator = validator;
        }

        [DebuggerStepThrough]
        public async Task<TResponse> Handle(TRequest message, CancellationToken token)
        {
            var validationResult = validator.Validate(message);

            if (validationResult.IsValid)
                return await handler.Handle(message, token);

            throw new ValidationException(validationResult.Errors);
        }
    }
}