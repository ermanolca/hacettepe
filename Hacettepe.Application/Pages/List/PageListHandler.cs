using Hacettepe.Application.Database;
using Hacettepe.Application.Listing;
using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Pages.List;

public class PageListHandler(HacettepeDbContext dbContext) : IRequestHandler<PageListRequest, DatatableResponse<PageDto>>
{
    public Task<DatatableResponse<PageDto>> Handle(PageListRequest request, CancellationToken cancellationToken)
    {
        var service = new DataTableService<Page>(dbContext);
        var data = service.GetDatatableObject(request, service.GetData());
        var response = new DatatableResponse<PageDto>()
        {
            Data = data.Data?.Select(x=> new PageDto(){ Id = x.Id, Slug = x.Slug, Title = x.Title }).ToList(),
            Draw = request.Draw,
            RecordsFiltered = data.RecordsFiltered,
            RecordsTotal = data.RecordsTotal
        };
        
        return Task.FromResult(response);
    }
}