using Hacettepe.Application.Database;
using Hacettepe.Domain;
using MediatR;

namespace Hacettepe.Application.Doctors.Edit;

public class SaveDoctorRequestHandler(HacettepeDbContext dbContext): IRequestHandler<SaveDoctorRequest, Doctor?>
{
    public async Task<Doctor?> Handle(SaveDoctorRequest request, CancellationToken cancellationToken)
    {
        Doctor? doctor;
        if (request.Id <= 0 || 
            (doctor = dbContext.Doctors.SingleOrDefault(x => x.Id == request.Id)) == null)
        {
            doctor = await CreateDoctor(request, cancellationToken);
        }
        else
        {
            doctor.Name = request.Name;
            doctor.Department = request.Department;
            doctor.ImageUrl = request.ImageUrl;
            doctor.Content = request.Content;
            doctor.Title = request.Title;
            doctor.Specialty = request.Specialty;
            doctor.Language = request.Language;
            dbContext.Doctors.Update(doctor);
        }
        
        await dbContext.SaveChangesAsync(cancellationToken);
        return doctor;
    }

    private async Task<Doctor?> CreateDoctor(SaveDoctorRequest request, CancellationToken cancellationToken)
    {
        var doctor = new Doctor()
        {
            Name = request.Name,
            Department = request.Department,
            ImageUrl = request.ImageUrl,
            Content = request.Content,
            Title = request.Title,
            Specialty = request.Specialty,
            Language = request.Language
        };

        await dbContext.Doctors.AddAsync(doctor, cancellationToken);
        return doctor;
    }
}