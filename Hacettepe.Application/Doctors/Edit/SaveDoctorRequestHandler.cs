using Hacettepe.Application.Database;
using Hacettepe.Application.Users.Edit;
using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Doctors.Edit;

public class SaveDoctorRequestHandler(HacettepeDbContext dbContext): IRequestHandler<SaveDoctorRequest, Doctor?>
{
    public async Task<Doctor?> Handle(SaveDoctorRequest request, CancellationToken cancellationToken)
    {
        return null;
    }

    private async Task<User> CreateDoctor(SaveUserRequest request, CancellationToken cancellationToken)
    {
        return null;
    }
}