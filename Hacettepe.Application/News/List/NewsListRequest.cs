using Hacettepe.Application.Listing;
using MediatR;

namespace Hacettepe.Application.News.List;

public class NewsListRequest : DatatableRequest, IRequest<DatatableResponse<NewsDto>>
{
    
}