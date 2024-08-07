using Hacettepe.Application.Common;

namespace Hacettepe.Application.Pages.List;

public class PageDto : TrackedDto
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string Slug { get; set; }
    
}