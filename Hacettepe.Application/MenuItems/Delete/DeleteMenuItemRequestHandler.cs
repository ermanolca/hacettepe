using Hacettepe.Application.Common;
using Hacettepe.Application.Database;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.MenuItems.Delete;

public class DeleteMenuItemRequestHandler(HacettepeDbContext dbContext): IRequestHandler<DeleteByIdRequest<MenuItem>>
{
    public async Task Handle(DeleteByIdRequest<MenuItem> request, CancellationToken cancellationToken)
    {
        var menuItem = await dbContext.MenuItems.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (menuItem != null)
        {
            dbContext.MenuItems.Remove(menuItem);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}