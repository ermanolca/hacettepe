using Hacettepe.Application.Listing;
using MediatR;

namespace Hacettepe.Application.Doctors.List;

public class DoctorListRequest : DatatableRequest, IRequest<DatatableResponse<DoctorDto>>
{
    
}