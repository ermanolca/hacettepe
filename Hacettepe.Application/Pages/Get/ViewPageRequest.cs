using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Pages.Get;

public class ViewPageRequest : IRequest<Page>
{
    public string Slug { get; set; }
}