using Hacettepe.Application.Common;
using Hacettepe.Application.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.News.Delete;

public class DeleteNewsRequestHandler(HacettepeDbContext dbContext): IRequestHandler<DeleteByIdRequest<Domain.News>>
{
    public async Task Handle(DeleteByIdRequest<Domain.News> request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (user != null)
        {
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}