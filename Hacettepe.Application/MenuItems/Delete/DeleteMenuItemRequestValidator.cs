using FluentValidation;
using Hacettepe.Application.Users.Delete;

namespace Hacettepe.Application.MenuItems.Delete;

public class DeleteMenuItemRequestValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteMenuItemRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage("İçerik bulunamadı");
    }
}