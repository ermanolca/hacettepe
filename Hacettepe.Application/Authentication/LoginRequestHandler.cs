using Hacettepe.Application.Database;
using Hacettepe.Application.Utils;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Authentication;

public class LoginRequestHandler(HacettepeDbContext dbContext) : IRequestHandler<LoginRequest, User?>
{
    public async Task<User?> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken: cancellationToken);
        if (user == null) return null;
        
        var hashedPassword = Hasher.Hash(request.Password, user.Salt);
        return user.Password == hashedPassword ? user : null;
    }
}