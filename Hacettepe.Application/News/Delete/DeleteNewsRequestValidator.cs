using FluentValidation;
using Hacettepe.Application.Common;

namespace Hacettepe.Application.News.Delete;

public class DeleteNewsRequestValidator : AbstractValidator<DeleteByIdRequest<Domain.News>>
{
    public DeleteNewsRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage("İçerik bulunamadı");
    }
}