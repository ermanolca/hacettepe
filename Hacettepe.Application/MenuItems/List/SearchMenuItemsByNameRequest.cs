using MediatR;

namespace Hacettepe.Application.MenuItems.List;

public class SearchMenuItemsByNameRequest : IRequest<IEnumerable<MenuItemDto>>
{
    public string Name { get; set; }
}