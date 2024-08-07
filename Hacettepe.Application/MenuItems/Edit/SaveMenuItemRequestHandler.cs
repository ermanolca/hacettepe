using System.Security.Cryptography;
using Hacettepe.Application.Database;
using Hacettepe.Application.Users.Edit;
using Hacettepe.Application.Utils;
using Hacettepe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hacettepe.Application.MenuItems.Edit;

public class SaveMenuItemRequestHandler(HacettepeDbContext dbContext): IRequestHandler<SaveMenuItemRequest, MenuItem?>
{
    public async Task<MenuItem?> Handle(SaveMenuItemRequest request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            return await CreateNewMenuItem(request, cancellationToken);
        }
        
        var menuItem = await dbContext.MenuItems.SingleOrDefaultAsync(x => x.Id == request.Id,
            cancellationToken: cancellationToken);

        if (menuItem == null)
        {
            return await CreateNewMenuItem(request, cancellationToken);
        }

        var parent = await GetParent(request.ParentId, cancellationToken);
        menuItem.Name = request.Name;
        menuItem.En_Url = request.En_Url;
        menuItem.En_Text = request.En_Text;
        menuItem.Tr_Url = request.Tr_Url;
        menuItem.Tr_Text = request.Tr_Text;
        menuItem.Parent = parent;
        menuItem.ParentId = parent?.Id;
        
        dbContext.MenuItems.Update(menuItem);
        await dbContext.SaveChangesAsync(cancellationToken);
        return menuItem;
    }

    private async Task<MenuItem?> GetParent(long? parentId, CancellationToken cancellationToken)
    {
        MenuItem? parent = null;
        if (parentId.GetValueOrDefault() > 0)
        {
            parent = await dbContext.MenuItems.SingleOrDefaultAsync(x => x.Id == parentId,
                cancellationToken: cancellationToken);
        }

        return parent;
    }
    
    private async Task<MenuItem> CreateNewMenuItem(SaveMenuItemRequest request, CancellationToken cancellationToken)
    {
        var parent = await GetParent(request.ParentId, cancellationToken);
        var newMenuItem = new MenuItem()
        {
            Name = request.Name,
            En_Url = request.En_Url,
            En_Text = request.En_Text,
            Tr_Url = request.Tr_Url,
            Tr_Text = request.Tr_Text,
            Parent = parent,
            ParentId = parent?.Id,
        };
        
        newMenuItem = (await dbContext.MenuItems.AddAsync(newMenuItem, cancellationToken)).Entity;
        
        await dbContext.SaveChangesAsync(cancellationToken);
        return newMenuItem;
    }
}