using Hacettepe.Application.Common;
using Hacettepe.Application.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.News.Get;

public class GetNewsByIdRequestHandler(HacettepeDbContext dbContext): IRequestHandler<GetByIdRequest<Domain.News>, Domain.News?>
{
    public async Task<Domain.News?> Handle(GetByIdRequest<Domain.News> request, CancellationToken cancellationToken)
    {
        var news = await dbContext.News.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return news;
    }
}