using Hacettepe.Application.Database;
using Hacettepe.Application.Listing;
using MediatR;

namespace Hacettepe.Application.News.List;

public class NewsListHandler(HacettepeDbContext dbContext) : IRequestHandler<NewsListRequest, DatatableResponse<NewsDto>>
{
    public Task<DatatableResponse<NewsDto>> Handle(NewsListRequest request, CancellationToken cancellationToken)
    {
        var service = new DataTableService<Domain.News>(dbContext);
        var data = service.GetDatatableObject(request, service.GetData());
        var response = new DatatableResponse<NewsDto>()
        {
            Data = data.Data?.Select(x=> new NewsDto(){ Id = x.Id, Title_Tr = x.Title, Title_En = x.Title }).ToList(),
            Draw = request.Draw,
            RecordsFiltered = data.RecordsFiltered,
            RecordsTotal = data.RecordsTotal
        };
        
        return Task.FromResult(response);
    }
}