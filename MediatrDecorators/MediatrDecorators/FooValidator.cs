using FluentValidation;
// ReSharper disable UnusedMember.Global

namespace MediatrDecorators
{
    public class FooValidator : AbstractValidator<Foo>
    {
        public FooValidator()
        {
            RuleFor(ping => ping.Message).NotEmpty();
        }
    }
}