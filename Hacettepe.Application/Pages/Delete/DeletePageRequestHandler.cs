using Hacettepe.Application.Common;
using Hacettepe.Application.Database;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Pages.Delete;

public class DeletePageRequestHandler(HacettepeDbContext dbContext): IRequestHandler<DeleteByIdRequest<Page>>
{
    public async Task Handle(DeleteByIdRequest<Page> request, CancellationToken cancellationToken)
    {
        var page = await dbContext.Pages.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (page != null)
        {
            dbContext.Pages.Remove(page);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}