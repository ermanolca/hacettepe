using Hacettepe.Application.Database;
using Hacettepe.Application.Listing;
using MediatR;

namespace Hacettepe.Application.MenuItems.List;

public class MenuItemListHandler(HacettepeDbContext dbContext) : IRequestHandler<MenuItemListRequest, DatatableResponse<MenuItemDto>>
{
    public Task<DatatableResponse<MenuItemDto>> Handle(MenuItemListRequest request, CancellationToken cancellationToken)
    {
        var service = new DataTableService<Domain.MenuItem>(dbContext);
        var data = service.GetDatatableObject(request, service.GetData());
        var response = new DatatableResponse<MenuItemDto>()
        {
            Data = data.Data?.Select(x=> new MenuItemDto()
            {
                Id = x.Id, Name = x.Name, 
                ParentName = x.Parent?.Name,
                Tr_Text = x.Tr_Text,
                En_Text = x.En_Text,
                Tr_Url = x.Tr_Url,
                En_Url = x.En_Url
                
            }).ToList(),
            Draw = request.Draw,
            RecordsFiltered = data.RecordsFiltered,
            RecordsTotal = data.RecordsTotal
        };
        
        return Task.FromResult(response);
    }
}