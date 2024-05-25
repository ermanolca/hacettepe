using FluentValidation;

namespace Hacettepe.Application.Pages;

public class CreatePageRequestValidator : AbstractValidator<CreatePageRequest>
{
    public CreatePageRequestValidator()
    {
        RuleFor(x => x.Title).NotNull()
            .NotEmpty().WithMessage("Lütfen geçerli bir sayfa başlığı giriniz");

        RuleFor(x => x.Content).NotNull()
            .NotEmpty().WithMessage("Lütfen bir içerik giriniz");
    }
}