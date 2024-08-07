using MediatR;

namespace Hacettepe.Application.News.Edit;

public class SaveNewsRequest : IRequest<Domain.News>
{
    public string Title_Tr { get; set; }
    
    public string Title_En { get; set; }

    public string ListingImgUrl { get; set; }

    public string Brief_Tr { get; set; }
    
    public string Brief_En { get; set; }
    
    public string FullTemplateId_Tr { get; set; }
    
    public string FullTemplateId_En { get; set; }
}