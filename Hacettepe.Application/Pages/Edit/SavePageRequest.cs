using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Pages.Edit;

public class SavePageRequest : IRequest<Page>
{
    public long Id { get; set; }
    
    public string Title { get; set; }
    
    public string Content_TR { get; set; }

    public string Slug { get; set; }
}