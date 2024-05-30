using Hacettepe.Application.Database;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Pages.Get;

public class ViewPageRequestHandler(HacettepeDbContext dbContext): IRequestHandler<ViewPageRequest, Page?>
{
    public async Task<Page?> Handle(ViewPageRequest request, CancellationToken cancellationToken)
    {
        var page = await dbContext.Pages.SingleOrDefaultAsync(x => x.Slug == request.Slug, cancellationToken: cancellationToken);
        return page;
    }
}