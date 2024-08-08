using FluentValidation;
using Hacettepe.Application.Common;
using Hacettepe.Domain;

namespace Hacettepe.Application.MenuItems.Delete;

public class DeleteMenuItemRequestValidator : AbstractValidator<DeleteByIdRequest<MenuItem>>
{
    public DeleteMenuItemRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage("İçerik bulunamadı");
    }
}