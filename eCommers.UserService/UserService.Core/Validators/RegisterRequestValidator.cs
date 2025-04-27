using Common.Helper.Enum;
using FluentValidation;
using UserService.Core.DTO;

namespace UserService.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(prop => prop.Email)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .EmailAddress().WithMessage("Invalid '{PropertyName}' format.");
            RuleFor(prop => prop.Password)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .MinimumLength(8).WithMessage("'{PropertyName}' must be contain minimum 8 letters")
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("'{PropertyName}' must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{PropertyName}' must contain one or more special characters.");
            RuleFor(prop => prop.Name)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .MaximumLength(50).WithMessage("'{PropertyName}' should not exceed more than 50 letters");
            RuleFor(prop => prop.Gender)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .IsInEnum();


        }
    }
}
