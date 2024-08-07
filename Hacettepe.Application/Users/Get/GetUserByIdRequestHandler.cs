using Hacettepe.Application.Database;
using Hacettepe.Application.Pages.Get;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Users.Get;

public class GetUserByIdRequestHandler(HacettepeDbContext dbContext): IRequestHandler<GetUserByIdRequest, User?>
{
    public async Task<User?> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return user;
    }
}