using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Users.Get;

public class GetUserByIdRequest(long id) : IRequest<User?>
{
    public long Id { get; } = id;
}