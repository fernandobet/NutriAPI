using FluentValidation;

namespace Nutri.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryValidator:AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("El id es requerido");                
            
        }
    }
}
