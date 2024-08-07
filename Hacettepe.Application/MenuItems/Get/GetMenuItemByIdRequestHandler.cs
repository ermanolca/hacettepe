using Hacettepe.Application.Database;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.MenuItems.Get;

public class GetMenuItemByIdRequestHandler(HacettepeDbContext dbContext): IRequestHandler<GetMenuItemByIdRequest, MenuItem?>
{
    public async Task<MenuItem?> Handle(GetMenuItemByIdRequest request, CancellationToken cancellationToken)
    {
        var menuItem = await dbContext.MenuItems.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return menuItem;
    }
}