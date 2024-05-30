using FluentValidation;

namespace Hacettepe.Application.Pages.Delete;

public class DeletePageRequestValidator : AbstractValidator<DeletePageRequest>
{
    public DeletePageRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage("İçerik bulunamadı");
    }
}