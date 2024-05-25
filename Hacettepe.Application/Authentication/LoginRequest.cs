using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Authentication;

public class LoginRequest : IRequest<User>
{
    public string Email { get; set; }
    
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}