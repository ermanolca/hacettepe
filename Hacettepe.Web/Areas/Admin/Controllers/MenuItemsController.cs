using Hacettepe.Application.Common;
using Hacettepe.Application.Listing;
using Hacettepe.Application.MenuItems.Edit;
using Hacettepe.Application.MenuItems.List;
using Hacettepe.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hacettepe.Web.Areas.Admin.Controllers;


[Area("Admin")]
public class MenuItemsController(ISender mediator): Controller
{
    [HttpGet]
    public ViewResult Create()
    {
        return View("Edit",new MenuItem());
    }
    
    [HttpPost]
    public async Task<ViewResult> Save(SaveMenuItemRequest saveMenuItemRequest)
    {
        var menuItem = await mediator.Send<MenuItem?>(saveMenuItemRequest);
        if (menuItem != null) return View("Edit", menuItem);
        
        ModelState.AddModelError("", "Kaydetme başarısız");
        
        return View("Edit", new MenuItem());
    }
    
    [HttpGet]
    public async Task<ViewResult> Edit(long? id)
    {
        var menuItem = await mediator.Send<MenuItem?>(new GetByIdRequest<MenuItem?>(id ?? 0));
        if (menuItem != null) return View(menuItem);
        
        ModelState.AddModelError("", "Kaydetme başarısız");
        
        return View(new MenuItem());
    }
    
    [HttpGet]
    public ViewResult List()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<JsonResult> Search(SearchMenuItemsByNameRequest request)
    {
        var menuItemList = await mediator.Send<IEnumerable<MenuItemDto>>(request);
        
        return Json(menuItemList);
    }
    
    [HttpPost]
    public async Task<JsonResult> List([FromForm]MenuItemListRequest request)
    {
        var menuItemList = await mediator.Send<DatatableResponse<MenuItemDto>?>(request);
        
        return Json(menuItemList);
    }

    [HttpPost]
    public async Task Delete(long? id)
    {
        await mediator.Send(new DeleteByIdRequest<MenuItem>() { Id = id ?? 0 });
        ViewBag.Message = "Silme başarılı";
    }
}