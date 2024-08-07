using FluentValidation;
using Hacettepe.Application.Users.Edit;

namespace Hacettepe.Application.News.Edit;

public class SaveNewsRequestValidator : AbstractValidator<SaveUserRequest>
{
    public SaveNewsRequestValidator()
    {
        RuleFor(x => x.Email).NotNull()
            .NotEmpty().EmailAddress().WithMessage("Lütfen geçerli bir sayfa başlığı giriniz");

        RuleFor(x => x.Name).NotNull()
            .NotEmpty().WithMessage("Lütfen bir içerik giriniz");
        
        RuleFor(x=> x.Role).IsInEnum().WithMessage("Lütfen rol seçiniz");
    }
}