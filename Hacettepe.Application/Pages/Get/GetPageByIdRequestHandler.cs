using Hacettepe.Application.Common;
using Hacettepe.Application.Database;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Pages.Get;

public class GetPageByIdRequestHandler(HacettepeDbContext dbContext): IRequestHandler<GetByIdRequest<Page>, Page?>
{
    public async Task<Page?> Handle(GetByIdRequest<Page> request, CancellationToken cancellationToken)
    {
        var page = await dbContext.Pages.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return page;
    }
}