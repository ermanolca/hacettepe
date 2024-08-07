using MediatR;

namespace Hacettepe.Application.News.Get;

public class GetNewsByIdRequest(long id) : IRequest<Domain.News?>
{
    public long Id { get; } = id;
}