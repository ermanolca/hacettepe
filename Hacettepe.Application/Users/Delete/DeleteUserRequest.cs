using MediatR;

namespace Hacettepe.Application.Users.Delete;

public class DeleteUserRequest : IRequest
{
    public long Id { get; set; }
}