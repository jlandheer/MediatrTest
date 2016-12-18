using ConsoleApp.Commands;
using FluentValidation;

namespace ConsoleApp.Validators
{
    public class TestCommandValidator : AbstractValidator<TestCommand>
    {
        public TestCommandValidator()
        {
            RuleFor(i => i.Message).NotEmpty().WithMessage("Vul iets in!");
        }
    }
}