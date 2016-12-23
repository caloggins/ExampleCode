using FluentValidation;

// ReSharper disable UnusedMember.Global

namespace MediatrDecorators.MultipleRules
{
    public class BarValidator : AbstractValidator<Bar>
    {
        public BarValidator()
        {
            RuleFor(target => target.Author).NotEmpty();
            RuleFor(target => target.Message).NotEmpty();
        }
    }
}