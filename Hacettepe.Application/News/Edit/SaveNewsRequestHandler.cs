using System.Security.Cryptography;
using Hacettepe.Application.Database;
using Hacettepe.Application.Users.Edit;
using Hacettepe.Application.Utils;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.News.Edit;

public class SaveNewsRequestHandler(HacettepeDbContext dbContext): IRequestHandler<SaveUserRequest, User?>
{
    public async Task<User?> Handle(SaveUserRequest request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            return await CreateNewUser(request, cancellationToken);
        }
        
        var user = await dbContext.Users.SingleOrDefaultAsync(x => x.Id == request.Id,
            cancellationToken: cancellationToken);

        if (user == null)
        {
            return await CreateNewUser(request, cancellationToken);
        }
        
        user.Name = request.Name;
        user.Email = request.Email;
        user.Role = request.Role;
        user.IsActive = request.IsActive;
        
        dbContext.Users.Update(user);
        await dbContext.SaveChangesAsync(cancellationToken);
        return user;
    }

    private async Task<User> CreateNewUser(SaveUserRequest request, CancellationToken cancellationToken)
    {
        var password = RandomGenerator.Generate();
        var salt = new byte[32];
        RandomNumberGenerator.Create().GetBytes(salt);
        var hashedPassword = Hasher.Hash(password, salt);
        var newUser = new User()
        {
            Name = request.Name,
            Email = request.Email,
            Password = hashedPassword,
            Role = request.Role,
            IsActive = request.IsActive,
            Salt = salt,
            Token = null
        };
        
        newUser = (await dbContext.Users.AddAsync(newUser, cancellationToken)).Entity;
        
        await dbContext.SaveChangesAsync(cancellationToken);
        return newUser;
    }
}