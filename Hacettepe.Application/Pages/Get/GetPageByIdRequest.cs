using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Pages.Get;

public class GetPageByIdRequest(long id) : IRequest<Page?>
{
    public long Id { get; } = id;
}