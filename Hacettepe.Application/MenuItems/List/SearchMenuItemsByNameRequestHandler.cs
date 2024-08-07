using Hacettepe.Application.Database;
using MediatR;

namespace Hacettepe.Application.MenuItems.List;

public class SearchMenuItemsByNameRequestHandler(HacettepeDbContext dbContext) : IRequestHandler<SearchMenuItemsByNameRequest, IEnumerable<MenuItemDto>>
{
    public Task<IEnumerable<MenuItemDto>> Handle(SearchMenuItemsByNameRequest request, CancellationToken cancellationToken)
    {
        var data = (IEnumerable<MenuItemDto>)dbContext.MenuItems
            .Where(x => x.Name.StartsWith(request.Name))
            .Select(x=> new MenuItemDto()
            {
                Id = x.Id, Name = x.Name,    
            }).ToList();
        
        return Task.FromResult(data);
    }
}