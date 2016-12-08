using System.Diagnostics;
using FluentValidation;
using MediatR;

namespace MediatrDecorators
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
        public TResponse Handle(TRequest message)
        {
            var validationResult = validator.Validate(message);

            if (validationResult.IsValid)
                return handler.Handle(message);

            throw new ValidationException(validationResult.Errors);
        }
    }
}