using FluentValidation;
using Hacettepe.Application.Users.Delete;

namespace Hacettepe.Application.News.Delete;

public class DeleteNewsRequestValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteNewsRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage("İçerik bulunamadı");
    }
}