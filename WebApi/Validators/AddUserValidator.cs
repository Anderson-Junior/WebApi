using FluentValidation;
using WebApi.Models.InputModels;

namespace WebApi.Validators
{
    public class AddUserValidator : AbstractValidator<UserInputModel>
    {
        public AddUserValidator()
        {
            RuleFor(x => x.UserName)
                .EmailAddress()
                    .WithMessage("UserName must be an email")
                .NotEmpty()
                    .WithMessage("UserName must not be null or empty")
                .MaximumLength(50)
                    .WithMessage("UserName must length be less than 50")
                .MinimumLength(5)
                    .WithMessage("UserName must length be more than 5");

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("Password must not be null or empty")
                .MaximumLength(20)
                    .WithMessage("Password must length be less than 20")
                .MinimumLength(8)
                    .WithMessage("Password must length be more than 8");

            RuleFor(x => x.Role)
               .NotEmpty()
                   .WithMessage("Role must not be null or empty")
               .MaximumLength(20)
                   .WithMessage("Role must length be less than 50")
               .MinimumLength(8)
                   .WithMessage("Role must length be more than 5");
        }  
    }
}
