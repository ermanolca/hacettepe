using FluentValidation;

namespace Hacettepe.Application.Users.Edit;

public class SaveUserRequestValidator : AbstractValidator<SaveUserRequest>
{
    public SaveUserRequestValidator()
    {
        RuleFor(x => x.Email).NotNull()
            .NotEmpty().EmailAddress().WithMessage("Lütfen geçerli bir sayfa başlığı giriniz");

        RuleFor(x => x.Name).NotNull()
            .NotEmpty().WithMessage("Lütfen bir içerik giriniz");
        
        RuleFor(x=> x.Role).IsInEnum().WithMessage("Lütfen rol seçiniz");
    }
}