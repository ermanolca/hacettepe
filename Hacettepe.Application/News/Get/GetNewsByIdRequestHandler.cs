using Hacettepe.Application.Database;
using Hacettepe.Application.Users.Get;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.News.Get;

public class GetNewsByIdRequestHandler(HacettepeDbContext dbContext): IRequestHandler<GetUserByIdRequest, User?>
{
    public async Task<User?> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return user;
    }
}