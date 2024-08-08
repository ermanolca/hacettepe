using FluentValidation;
using Hacettepe.Application.Common;
using Hacettepe.Domain;

namespace Hacettepe.Application.Doctors.Delete;

public class DeleteDoctorRequestValidator : AbstractValidator<DeleteByIdRequest<Doctor>>
{
    public DeleteDoctorRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage("İçerik bulunamadı");
    }
}