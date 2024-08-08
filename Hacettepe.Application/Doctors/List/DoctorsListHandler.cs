using Hacettepe.Application.Database;
using Hacettepe.Application.Listing;
using MediatR;

namespace Hacettepe.Application.Doctors.List;

public class DoctorListHandler(HacettepeDbContext dbContext) : IRequestHandler<DoctorListRequest, DatatableResponse<DoctorDto>>
{
    public Task<DatatableResponse<DoctorDto>> Handle(DoctorListRequest request, CancellationToken cancellationToken)
    {
        var service = new DataTableService<Domain.Doctor>(dbContext);
        var data = service.GetDatatableObject(request, service.GetData());
        var response = new DatatableResponse<DoctorDto>()
        {
            Data = data.Data?.Select(x=> new DoctorDto(){ }).ToList(),
            Draw = request.Draw,
            RecordsFiltered = data.RecordsFiltered,
            RecordsTotal = data.RecordsTotal
        };
        
        return Task.FromResult(response);
    }
}