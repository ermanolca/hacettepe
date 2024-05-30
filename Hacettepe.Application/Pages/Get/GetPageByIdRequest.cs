using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Pages.Get;

public class GetPageByIdRequest : IRequest<Page?>
{
    public GetPageByIdRequest(long id)
    {
        Id = id;
    }
    public long Id { get; }
}