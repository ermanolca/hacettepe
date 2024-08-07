using MediatR;

namespace Hacettepe.Application.Users.Password;

public class ForgotPasswordRequest : IRequest
{
    public string? Email { get; set; }
}