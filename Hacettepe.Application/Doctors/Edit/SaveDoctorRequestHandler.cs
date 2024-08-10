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
            doctor.Bolum_En = request.Bolum_En;
            doctor.Bolum_Tr = request.Bolum_Tr;
            doctor.Email = request.Email;
            doctor.ImageUrl = request.ImageUrl;
            doctor.Tel = request.Tel;
            doctor.TemplateId_En = request.TemplateId_En;
            doctor.TemplateId_Tr = request.TemplateId_Tr;
            doctor.Unvan_En = request.Unvan_En;
            doctor.Unvan_Tr = request.Unvan_Tr;
            doctor.Uzman_En = request.Uzman_En;
            doctor.Uzman_Tr = request.Uzman_Tr;
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
            Bolum_En = request.Bolum_En,
            Bolum_Tr = request.Bolum_Tr,
            Email = request.Email,
            ImageUrl = request.ImageUrl,
            Tel = request.Tel,
            TemplateId_En = request.TemplateId_En,
            TemplateId_Tr = request.TemplateId_Tr,
            Unvan_En = request.Unvan_En,
            Unvan_Tr = request.Unvan_Tr,
            Uzman_En = request.Uzman_En,
            Uzman_Tr = request.Uzman_Tr
        };

        await dbContext.Doctors.AddAsync(doctor, cancellationToken);
        return doctor;
    }
}