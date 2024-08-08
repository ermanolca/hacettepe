using Hacettepe.Application.Common;
using Hacettepe.Application.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Doctors.Get;

public class GetDoctorByIdRequestHandler(HacettepeDbContext dbContext): IRequestHandler<GetByIdRequest<Domain.Doctor>, Domain.Doctor?>
{
    public async Task<Domain.Doctor?> Handle(GetByIdRequest<Domain.Doctor> request, CancellationToken cancellationToken)
    {
        var doctor = await dbContext.Doctors.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return doctor;
    }
}