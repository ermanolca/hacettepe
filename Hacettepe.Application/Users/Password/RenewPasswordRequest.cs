using Hacettepe.Application.Common;
using MediatR;

namespace Hacettepe.Application.Users.Password;

public class RenewPasswordRequest : IRequest<HandlerResult>, IRequest
{
    public string NewPassword { get; set; }
    
    public string NewPasswordConfirmation { get; set; }

    public string Token { get; set; }
}