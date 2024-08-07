using Hacettepe.Application.Database;
using Hacettepe.Application.Users.Delete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.News.Delete;

public class DeleteNewsRequestHandler(HacettepeDbContext dbContext): IRequestHandler<DeleteUserRequest>
{
    public async Task Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (user != null)
        {
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}