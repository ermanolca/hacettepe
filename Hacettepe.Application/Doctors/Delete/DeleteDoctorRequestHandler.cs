using Hacettepe.Application.Common;
using Hacettepe.Application.Database;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Doctors.Delete;

public class DeleteDoctorRequestHandler(HacettepeDbContext dbContext): IRequestHandler<DeleteByIdRequest<Doctor>>
{
    public async Task Handle(DeleteByIdRequest<Doctor> request, CancellationToken cancellationToken)
    {
        var doctor = await dbContext.Doctors.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (doctor != null)
        {
            dbContext.Doctors.Remove(doctor);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}