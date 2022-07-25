using FluentValidation;

namespace Nutri.Application.Features.Users.Commands.AddUser
{
    public class AddUserCommandValidator:AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("{Email} no puede ser nulo");
            RuleFor(x => x.Password)
                .NotNull().WithMessage("{Password} no puede ser nulo");
        }
    }
}
