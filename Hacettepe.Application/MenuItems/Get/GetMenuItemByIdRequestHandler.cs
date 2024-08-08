using Hacettepe.Application.Common;
using Hacettepe.Application.Database;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.MenuItems.Get;

public class GetMenuItemByIdRequestHandler(HacettepeDbContext dbContext): IRequestHandler<GetByIdRequest<Domain.MenuItem>, MenuItem?>
{
    public async Task<MenuItem?> Handle(GetByIdRequest<Domain.MenuItem> request, CancellationToken cancellationToken)
    {
        var menuItem = await dbContext.MenuItems.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return menuItem;
    }
}