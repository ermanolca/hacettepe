namespace Hacettepe.Application.Authentication.Infrastructure;

public class UserSession : IUserSession
{
    public string LoginName { get; set; }

    public bool IsAuthenticated { get; set; }
}