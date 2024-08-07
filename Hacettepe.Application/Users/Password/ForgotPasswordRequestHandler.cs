using System.Text;
using Hacettepe.Application.Authentication;
using Hacettepe.Application.Database;
using Hacettepe.Application.Mailing;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Hacettepe.Application.Users.Password;

public class ForgotPasswordRequestHandler(HacettepeDbContext _dbContext, IMailService _mailService, IOptions<MailSettings> _mailSettings) : IRequestHandler<ForgotPasswordRequest>
{
    public async Task Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken: cancellationToken);
        if (user != null)
        {
            var token = GenerateToken();
            user.Token = token;
            _dbContext.Users.Update(user);
            var renewPasswordUrl = $"https://hastane.hacettepe.edu.tr/admin/user/renewpassword/{token}";
            var to = new List<string> { user.Email };
            var mailRequest = new MailRequest(
                to,
                "Hacettepe Üniversitesi Hastanesi Admin Paneli Şifre Yenileme İsteği",
                $"Şifrenizi {renewPasswordUrl} bağlantısına tıklayarak yenileyebilirsiniz",
                _mailSettings.Value.From,
                _mailSettings.Value.DisplayName);

            await _mailService.SendAsync(mailRequest, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
    
    private static string GenerateToken()
    {
        var time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
        var key = Guid.NewGuid().ToByteArray();
        
        return Convert.ToBase64String(time.Concat(key).ToArray());
    }
}