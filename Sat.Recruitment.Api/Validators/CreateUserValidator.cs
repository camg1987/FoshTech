using FluentValidation;
using Sat.Recruitment.Dto.Request;

namespace Sat.Recruitment.Api.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("The name is required");
            RuleFor(u => u.Email).NotEmpty().WithMessage("The email is required");
            RuleFor(u => u.Address).NotEmpty().WithMessage("The address is required");
            RuleFor(u => u.Phone).NotEmpty().WithMessage("The phone is required");
        }
    }
}
