using Hacettepe.Application.Listing;
using Hacettepe.Application.Users.List;
using MediatR;

namespace Hacettepe.Application.Audits.List;

public class AuditListRequest : DatatableRequest, IRequest<DatatableResponse<AuditDto>>
{
    
}