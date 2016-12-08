using FluentValidation;
// ReSharper disable UnusedMember.Global

namespace MediatrDecorators
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