using MediatR;

namespace Hacettepe.Application.Common;

public class DeleteByIdRequest<T> : IRequest
{
    public long Id { get; set; }
}