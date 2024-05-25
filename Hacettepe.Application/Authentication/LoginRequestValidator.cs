using FluentValidation;
using FluentValidation.Validators;

namespace Hacettepe.Application.Authentication;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email).NotNull()
            .NotEmpty().WithMessage("Lütfen email adresinizi giriniz")
            .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
            .WithMessage("Lütfen geçerli bir email adresi giriniz");
        
        RuleFor(x => x.Password).NotNull()
            .NotEmpty().WithMessage("Lütfen şifrenizi giriniz")
            .MinimumLength(6).WithMessage("Lütfen minimum 6 karakter giriniz");;
    }
}