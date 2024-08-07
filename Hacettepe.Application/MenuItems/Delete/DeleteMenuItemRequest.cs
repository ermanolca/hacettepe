using MediatR;

namespace Hacettepe.Application.MenuItems.Delete;

public class DeleteMenuItemRequest : IRequest
{
    public long Id { get; set; }
}