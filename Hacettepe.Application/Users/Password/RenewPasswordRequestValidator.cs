using FluentValidation;

namespace Hacettepe.Application.Users.Password;

public class RenewPasswordRequestValidator : AbstractValidator<RenewPasswordRequest>
{
    public RenewPasswordRequestValidator()
    {
        RuleFor(x => x.Token).NotNull()
            .NotEmpty().WithMessage("Geçersiz token değeri");

        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("Lütfen şifrenizi giriniz")
            .MinimumLength(8).WithMessage("Lütfen minimum 6 karakter giriniz")
            .Matches(@"[A-Z]+").WithMessage("Şifre en az 1 büyük harf içermelidir")
            .Matches(@"[a-z]+").WithMessage("Şifre en az bir küçük harf içermelidir")
            .Matches(@"[0-9]+").WithMessage("Şifre en az bir rakam içermelidir")
            .Matches(@"[^a-zA-Z\d\s:]+").WithMessage("Şifre boşluk ve : haricinde en az bir özel karakter içermelidir");

        RuleFor(x => x.NewPassword).NotNull()
            .NotEmpty().WithMessage("Yeni şifrenizi giriniz")
            .Equal(customer => customer.NewPasswordConfirmation)
            .WithMessage("Şifre girişleriniz aynı değil");

        RuleFor(x => x.NewPasswordConfirmation).NotNull()
            .NotEmpty().WithMessage("Şifrenizin tekrarını giriniz");
    }
}