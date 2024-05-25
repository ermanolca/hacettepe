using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Pages;

public class ViewPageRequest : IRequest<Page>
{
    public string Slug { get; set; }
}