using ConsoleApp.Commands;
using FluentValidation;

namespace ConsoleApp.Validators
{
    public class PingValidator : AbstractValidator<Ping>
    {
        public PingValidator()
        {
            RuleFor(i => i.Message).NotEmpty().WithMessage("Vul iets in!");
        }
    }
}