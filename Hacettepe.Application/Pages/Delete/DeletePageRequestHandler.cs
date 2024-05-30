using Hacettepe.Application.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Pages.Delete;

public class DeletePageRequestHandler(HacettepeDbContext dbContext): IRequestHandler<DeletePageRequest>
{
    public async Task Handle(DeletePageRequest request, CancellationToken cancellationToken)
    {
        var page = await dbContext.Pages.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (page != null)
        {
            dbContext.Pages.Remove(page);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}