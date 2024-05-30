using Hacettepe.Application.Listing;
using MediatR;

namespace Hacettepe.Application.Pages.List;

public class PageListRequest : DatatableRequest, IRequest<DatatableResponse<PageDto>>
{
    
}