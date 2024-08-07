using FluentValidation;
using Hacettepe.Application.Users.Edit;

namespace Hacettepe.Application.MenuItems.Edit;

public class SaveMenuItemRequestValidator : AbstractValidator<SaveUserRequest>
{
    public SaveMenuItemRequestValidator()
    {
        RuleFor(x => x.Email).NotNull()
            .NotEmpty().EmailAddress().WithMessage("Lütfen geçerli bir sayfa başlığı giriniz");

        RuleFor(x => x.Name).NotNull()
            .NotEmpty().WithMessage("Lütfen bir içerik giriniz");
        
        RuleFor(x=> x.Role).IsInEnum().WithMessage("Lütfen rol seçiniz");
    }
}