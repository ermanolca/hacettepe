using MediatR;

namespace Hacettepe.Application.News.Delete;

public class DeleteNewsRequest : IRequest
{
    public long Id { get; set; }
}