using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Pages;

public class CreatePageRequest : IRequest<Page>
{
    public string Title { get; set; }
    
    public string Content { get; set; }

    public string Slug { get; set; }
}