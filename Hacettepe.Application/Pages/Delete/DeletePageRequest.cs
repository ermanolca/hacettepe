using MediatR;

namespace Hacettepe.Application.Pages.Delete;

public class DeletePageRequest : IRequest
{
    public long Id { get; set; }
}