using Hacettepe.Application.Listing;
using Hacettepe.Application.Pages.Delete;
using Hacettepe.Application.Pages.Edit;
using Hacettepe.Application.Pages.Get;
using Hacettepe.Application.Pages.List;
using Hacettepe.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hacettepe.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class PagesController(ISender mediator) : Controller
{
    [HttpGet]
    public ViewResult Create()
    {
        return View("deneme",new Page());
    }
    
    [HttpPost]
    public async Task<ViewResult> Save(SavePageRequest savePageRequest)
    {
        var page = await mediator.Send<Page?>(savePageRequest);
        if (page != null) return View("Edit", page);
        
        ModelState.AddModelError("", "Kaydetme başarısız");
        
        return View("Edit", new Page());
    }
    
    [HttpGet]
    public async Task<ViewResult> Edit(long? id)
    {
        var page = await mediator.Send<Page?>(new GetPageByIdRequest(id ?? 0));
        if (page != null) return View(page);
        
        ModelState.AddModelError("", "Kaydetme başarısız");
        
        return View(new Page());
    }
    
    [HttpGet]
    public ViewResult List()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<JsonResult> List([FromForm]PageListRequest request)
    {
        var pageList = await mediator.Send<DatatableResponse<PageDto>?>(request);
        
        return Json(pageList);
    }

    [HttpDelete]
    public async Task Delete(long? id)
    {
        await mediator.Send<DeletePageRequest>(new DeletePageRequest() {Id = id ?? 0});
    }
}