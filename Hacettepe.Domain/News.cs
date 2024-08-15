
namespace Hacettepe.Domain;

public class News : EntityBase
{
    public string Title { get; set; }

    public string ListingImgUrl { get; set; }
    
    public string Brief { get; set; }
    
    public string Category { get; set; }
    
    public string Content { get; set; }
    
    public Languages Language { get; set; }
}