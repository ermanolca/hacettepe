using Hacettepe.Application.Database;
using Hacettepe.Application.Utils;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Pages;

public class CreatePageRequestHandler(HacettepeDbContext dbContext): IRequestHandler<CreatePageRequest, Page?>
{
    public async Task<Page?> Handle(CreatePageRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Slug))
        {
            request.Slug = SlugUtil.Slugify(request.Title);
        }
        else
        {
            request.Slug = SlugUtil.Slugify(request.Slug);
        }
        
        var page = await dbContext.Pages.SingleOrDefaultAsync(x => x.Slug == request.Slug, cancellationToken: cancellationToken);
        if (page != null)
        {
            return page;
        }

        page = new Page()
        {
            Title = request.Title,
            Content_TR = request.Content,
            Slug = request.Slug
        };
        var savedPage = await dbContext.Pages.AddAsync(page, cancellationToken);
        await dbContext.SaveChangesAsync();
        return savedPage.Entity;
    }
}