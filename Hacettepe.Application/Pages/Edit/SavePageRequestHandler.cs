using Hacettepe.Application.Database;
using Hacettepe.Application.Utils;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Pages.Edit;

public class SavePageRequestHandler(HacettepeDbContext dbContext): IRequestHandler<SavePageRequest, Page?>
{
    public async Task<Page?> Handle(SavePageRequest request, CancellationToken cancellationToken)
    {
        request.Slug = SlugUtil.Slugify(string.IsNullOrEmpty(request.Slug) ? request.Title : request.Slug);

        var page = await dbContext.Pages.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (page != null)
        {
            page.Title = request.Title;
            page.Content_TR = request.Content_TR;
            page.Slug = request.Slug;
            dbContext.Pages.Update(page);
        }
        else
        {
            page = new Page()
            {
                Title = request.Title,
                Content_TR = request.Content_TR,
                Slug = request.Slug
            };
            page = (await dbContext.Pages.AddAsync(page, cancellationToken)).Entity;
        }
        
        await dbContext.SaveChangesAsync(cancellationToken);
        return page;
    }
}