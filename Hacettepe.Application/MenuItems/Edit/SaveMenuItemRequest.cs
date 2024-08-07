using MediatR;

namespace Hacettepe.Application.MenuItems.Edit;

public class SaveMenuItemRequest : IRequest<Domain.MenuItem>
{
    public long Id { get; set; }
    public string Name { get; set; }

    public long? ParentId { get; set; }

    public string Tr_Text { get; set; }
    
    public string En_Text { get; set; }

    public string Tr_Url { get; set; }
    
    public string En_Url { get; set; }
}