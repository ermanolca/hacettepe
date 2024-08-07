using System.Security.Cryptography;
using Hacettepe.Application.Common;
using Hacettepe.Application.Database;
using Hacettepe.Application.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.Users.Password;

public class RenewPasswordRequestHandler(HacettepeDbContext _dbContext) : IRequestHandler<RenewPasswordRequest, HandlerResult>
{
    public async Task<HandlerResult> Handle(RenewPasswordRequest request, CancellationToken cancellationToken)
    {
        
        var data = Convert.FromBase64String(request.Token);
        var when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
        if (when < DateTime.UtcNow.AddHours(-24))
        {
            return new HandlerResult(false, "İsteğin süresi dolmuş. Lütfen tekrar yenileme isteği yapınız");
        }

        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Token == request.Token, cancellationToken: cancellationToken);
        if (user == null)
        {
            return new HandlerResult(true, "Geçersiz yenileme isteği.");
        }
       
        var salt = new byte[32];
        RandomNumberGenerator.Create().GetBytes(salt);
        var hashedPassword = Hasher.Hash(request.NewPasswordConfirmation, salt);

        user.Password = hashedPassword;
        user.Salt = salt;
        user.Token = null;
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new HandlerResult(true, "Şifreniz başarıyla değiştirildi. Yeni şifrenizle giriş yapınız.");
    }
}

