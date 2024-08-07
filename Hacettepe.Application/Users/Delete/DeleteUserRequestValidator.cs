using FluentValidation;

namespace Hacettepe.Application.Users.Delete;

public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage("İçerik bulunamadı");
    }
}