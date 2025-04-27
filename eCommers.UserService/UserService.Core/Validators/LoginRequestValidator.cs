using FluentValidation;
using UserService.Core.DTO;

namespace UserService.Core.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(arg => arg.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email format.");
            RuleFor(arg => arg.Password)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .MinimumLength(8).WithMessage("'{PropertyName}' must be contain minimum 8 letters")
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("'{PropertyName}' must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{PropertyName}' must contain one or more special characters.");
        }
    }
}
