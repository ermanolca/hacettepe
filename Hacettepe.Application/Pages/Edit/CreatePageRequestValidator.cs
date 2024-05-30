using FluentValidation;

namespace Hacettepe.Application.Pages.Edit;

public class CreatePageRequestValidator : AbstractValidator<SavePageRequest>
{
    public CreatePageRequestValidator()
    {
        RuleFor(x => x.Title).NotNull()
            .NotEmpty().WithMessage("Lütfen geçerli bir sayfa başlığı giriniz");

        RuleFor(x => x.Content_TR).NotNull()
            .NotEmpty().WithMessage("Lütfen bir içerik giriniz");
    }
}