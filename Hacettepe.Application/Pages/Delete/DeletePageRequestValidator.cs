using FluentValidation;
using Hacettepe.Application.Common;
using Hacettepe.Domain;

namespace Hacettepe.Application.Pages.Delete;

public class DeletePageRequestValidator : AbstractValidator<DeleteByIdRequest<Page>>
{
    public DeletePageRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage("İçerik bulunamadı");
    }
}