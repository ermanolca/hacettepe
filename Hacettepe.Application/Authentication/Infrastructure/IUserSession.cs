namespace Hacettepe.Application.Authentication.Infrastructure;

public interface IUserSession
{
    string LoginName { get; set; }

    bool IsAuthenticated { get; set; }
}


