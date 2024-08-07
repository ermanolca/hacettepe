using Hacettepe.Application.Listing;
using Hacettepe.Application.Pages.List;
using MediatR;

namespace Hacettepe.Application.Users.List;

public class UserListRequest : DatatableRequest, IRequest<DatatableResponse<UserDto>>
{
    
}