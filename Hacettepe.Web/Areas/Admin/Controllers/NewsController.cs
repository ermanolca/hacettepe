using Hacettepe.Application.Common;
using Hacettepe.Application.Listing;
using Hacettepe.Application.News.Edit;
using Hacettepe.Application.News.List;
using Hacettepe.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hacettepe.Web.Areas.Admin.Controllers;


[Area("Admin")]
public class NewsController(ISender mediator): Controller
{
    [HttpGet]
    public ViewResult Create()
    {
        return View("Edit",new News());
    }
    
    [HttpPost]
    public async Task<ViewResult> Save(SaveNewsRequest saveNewsRequest)
    {
        var news = await mediator.Send<News?>(saveNewsRequest);
        if (news != null) return View("Edit", news);
        
        ModelState.AddModelError("", "Kaydetme başarısız");
        
        return View("Edit", new News());
    }
    
    [HttpGet]
    public async Task<ViewResult> Edit(long? id)
    {
        var news = await mediator.Send(new GetByIdRequest<News?>(id ?? 0));
        if (news != null) return View(news);
        
        ModelState.AddModelError("", "Kaydetme başarısız");
        
        return View(new News());
    }
    
    [HttpGet]
    public ViewResult List()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<JsonResult> List([FromForm]NewsListRequest request)
    {
        var NewsList = await mediator.Send<DatatableResponse<NewsDto>?>(request);
        
        return Json(NewsList);
    }

    [HttpPost]
    public async Task Delete(long? id)
    {
        await mediator.Send(new DeleteByIdRequest<News>() { Id = id ?? 0 });
        ViewBag.Message = "Silme başarılı";
    }
}