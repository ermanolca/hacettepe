using Hacettepe.Application.Database;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Pages.Get;

public class GetPageByIdRequestHandler(HacettepeDbContext dbContext): IRequestHandler<GetPageByIdRequest, Page?>
{
    public async Task<Page?> Handle(GetPageByIdRequest request, CancellationToken cancellationToken)
    {
        var page = await dbContext.Pages.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return page;
    }
}