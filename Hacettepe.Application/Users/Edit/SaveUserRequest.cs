using Hacettepe.Domain;
using Hacettepe.Domain.Enums;
using MediatR;

namespace Hacettepe.Application.Users.Edit;

public class SaveUserRequest : IRequest<User>
{
    public long Id { get; set; }
    
    public string Name { get; set; }

    public string Email { get; set; }

    public Roles Role { get; set; }

    public bool IsActive { get; set; }
}