using Hacettepe.Application.Audits.List;
using Hacettepe.Application.Listing;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hacettepe.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class AuditsController(ISender mediator): Controller
{
    [HttpGet]
    public ViewResult List()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<JsonResult> List([FromForm]AuditListRequest request)
    {
        var auditList = await mediator.Send<DatatableResponse<AuditDto>?>(request);
        
        return Json(auditList);
    }
}