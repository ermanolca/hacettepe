using MediatR;

namespace Hacettepe.Application.Common;

public class GetByIdRequest<T>(long id) : IRequest<T>
{
    public long Id { get; } = id;
}