using Hacettepe.Application.Database;
using Hacettepe.Application.Listing;
using Hacettepe.Application.Users.List;
using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Audits.List;

public class AuditListHandler(HacettepeDbContext dbContext) : IRequestHandler<AuditListRequest, DatatableResponse<AuditDto>>
{
    public Task<DatatableResponse<AuditDto>> Handle(AuditListRequest request, CancellationToken cancellationToken)
    {
        var service = new DataTableService<Audit>(dbContext);
        var data = service.GetDatatableObject(request, service.GetData());
        var response = new DatatableResponse<AuditDto>()
        {
            Data = data.Data?.Select(x=> new AuditDto()
            {
                Id = x.Id,
                AffectedColumns = x.AffectedColumns,
                NewValues = x.NewValues,
                OccurrenceDateTime = x.OccurrenceDateTime,
                OldValues = x.OldValues,
                PrimaryKey = x.PrimaryKey,
                TableName = x.TableName,
                Type = x.Type,
                User = x.User
          }).ToList(),
            Draw = request.Draw,
            RecordsFiltered = data.RecordsFiltered,
            RecordsTotal = data.RecordsTotal
        };
        
        return Task.FromResult(response);
    }
}