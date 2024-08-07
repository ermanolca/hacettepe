using Hacettepe.Application.Listing;
using MediatR;

namespace Hacettepe.Application.MenuItems.List;

public class MenuItemListRequest : DatatableRequest, IRequest<DatatableResponse<MenuItemDto>>
{
    
}