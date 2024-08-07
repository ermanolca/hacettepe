using MediatR;

namespace Hacettepe.Application.MenuItems.Get;

public class GetMenuItemByIdRequest(long id) : IRequest<Domain.MenuItem?>
{
    public long Id { get; } = id;
}