using FluentValidation;

namespace Hacettepe.Application.Doctors.Edit;

public class SaveDoctorRequestValidator : AbstractValidator<SaveDoctorRequest>
{
    public SaveDoctorRequestValidator()
    {
    }
}