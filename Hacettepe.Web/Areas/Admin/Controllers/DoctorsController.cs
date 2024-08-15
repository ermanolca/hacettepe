using Hacettepe.Application.Common;
using Hacettepe.Application.Doctors.Edit;
using Hacettepe.Application.Doctors.List;
using Hacettepe.Application.Listing;
using Hacettepe.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hacettepe.Web.Areas.Admin.Controllers;


[Area("Admin")]
public class DoctorsController(ISender mediator): Controller
{
    [HttpGet]
    public ViewResult Create()
    {
        return View("Edit",new SaveDoctorRequest());
    }
    
    [HttpPost]
    public async Task<ViewResult> Save(SaveDoctorRequest saveDoctorRequest)
    {
        var doctor = await mediator.Send<Doctor?>(saveDoctorRequest);
        if (doctor != null)
        {
            saveDoctorRequest.Id = doctor.Id;
            return View("Edit", saveDoctorRequest);
        }
        
        ModelState.AddModelError("", "Kaydetme başarısız");
        
        return View("Edit", new SaveDoctorRequest());
    }
    
    [HttpGet]
    public async Task<ViewResult> Edit(long? id)
    {
        var doctor = await mediator.Send(new GetByIdRequest<Doctor?>(id ?? 0));
        if (doctor != null)
        {
            var modelView = new SaveDoctorRequest()
            {
                Name = doctor.Name,
                Title = doctor.Title,
                Department = doctor.Department,
                Specialty = doctor.Specialty,
                ImageUrl = doctor.ImageUrl,
                Content = doctor.Content
            };
            
            return View(modelView);
        }
        
        ModelState.AddModelError("", "Kaydetme başarısız");
        
        return View(new SaveDoctorRequest());
    }
    
    [HttpGet]
    public ViewResult List()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<JsonResult> List([FromForm]DoctorListRequest request)
    {
        var doctorList = await mediator.Send<DatatableResponse<DoctorDto>?>(request);
        
        return Json(doctorList);
    }

    [HttpPost]
    public async Task Delete(long? id)
    {
        await mediator.Send(new DeleteByIdRequest<Doctor>() { Id = id ?? 0 });
        ViewBag.Message = "Silme başarılı";
    }
}