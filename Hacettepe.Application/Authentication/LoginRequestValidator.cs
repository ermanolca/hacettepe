using FluentValidation;
using FluentValidation.Validators;

namespace Hacettepe.Application.Authentication;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email).NotNull()
            .WithMessage("Lütfen email adresinizi giriniz")
            .NotEmpty().WithMessage("Lütfen email adresinizi giriniz")
            .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
            .WithMessage("Lütfen geçerli bir email adresi giriniz");
        
        RuleFor(x => x.Password).NotNull()
            .WithMessage("Lütfen email adresinizi giriniz")
            .NotEmpty().WithMessage("Lütfen şifrenizi giriniz")
            .MinimumLength(8).WithMessage("Lütfen minimum 8 karakter giriniz");;
    }
}