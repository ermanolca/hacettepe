using System.Security.Cryptography;
using Hacettepe.Application.Database;
using Hacettepe.Application.Listing;
using Hacettepe.Application.Utils;
using Hacettepe.Domain;
using Hacettepe.Domain.Enums;
using MediatR;

namespace Hacettepe.Application.Users.List;

public class UserListHandler(HacettepeDbContext dbContext) : IRequestHandler<UserListRequest, DatatableResponse<UserDto>>
{
    public async Task<DatatableResponse<UserDto>> Handle(UserListRequest request, CancellationToken cancellationToken)
    {
        var service = new DataTableService<User>(dbContext);
        var data = service.GetDatatableObject(request, service.GetData());
        var response = new DatatableResponse<UserDto>()
        {
            Data = data.Data?.Select(x=> new UserDto(){ Id = x.Id, Name = x.Name, Email = x.Email }).ToList(),
            Draw = request.Draw,
            RecordsFiltered = data.RecordsFiltered,
            RecordsTotal = data.RecordsTotal
        };

        return response;
    }
}