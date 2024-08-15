using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Doctors.Edit;

public class SaveDoctorRequest : IRequest<Domain.Doctor>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Specialty { get; set; }
    public string Department { get; set; }
    public string ImageUrl { get; set; }
    public string Content { get; set; }
    public Languages Language { get; set; }
}