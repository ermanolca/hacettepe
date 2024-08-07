using FluentValidation;
using FluentValidation.Validators;
using Hacettepe.Application.Users.Password;

namespace Hacettepe.Application.Authentication;

public class ForgotPasswordRequestValidator : AbstractValidator<ForgotPasswordRequest>
{
    public ForgotPasswordRequestValidator()
    {
        RuleFor(x => x.Email).NotNull()
            .NotEmpty().WithMessage("Lütfen email adresinizi giriniz")
            .EmailAddress()
            .WithMessage("Lütfen geçerli bir email adresi giriniz"); 
    }
}