using FluentValidation;
using Hacettepe.Application.Common;
using Hacettepe.Domain;

namespace Hacettepe.Application.Users.Delete;

public class DeleteUserRequestValidator : AbstractValidator<DeleteByIdRequest<User>>
{
    public DeleteUserRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage("İçerik bulunamadı");
    }
}