using Hacettepe.Application.Common;
using Hacettepe.Application.Database;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Users.Get;

public class GetUserByIdRequestHandler(HacettepeDbContext dbContext): IRequestHandler<GetByIdRequest<User>, User?>
{
    public async Task<User?> Handle(GetByIdRequest<User> request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return user;
    }
}