using Hacettepe.Application.Listing;
using Hacettepe.Application.Users.Delete;
using Hacettepe.Application.Users.Edit;
using Hacettepe.Application.Users.Get;
using Hacettepe.Application.Users.List;
using Hacettepe.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hacettepe.Web.Areas.Admin.Controllers;


[Area("Admin")]
public class UsersController(ISender mediator): Controller
{
    [HttpGet]
    public ViewResult Create()
    {
        return View("Edit",new User());
    }
    
    [HttpPost]
    public async Task<ViewResult> Save(SaveUserRequest saveUserRequest)
    {
        var user = await mediator.Send<User?>(saveUserRequest);
        if (user != null) return View("Edit", user);
        
        ModelState.AddModelError("", "Kaydetme başarısız");
        
        return View("Edit", new User());
    }
    
    [HttpGet]
    public async Task<ViewResult> Edit(long? id)
    {
        var user = await mediator.Send<User?>(new GetUserByIdRequest(id ?? 0));
        if (user != null) return View(user);
        
        ModelState.AddModelError("", "Kaydetme başarısız");
        
        return View(new User());
    }
    
    [HttpGet]
    public ViewResult List()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<JsonResult> List([FromForm]UserListRequest request)
    {
        var userList = await mediator.Send<DatatableResponse<UserDto>?>(request);
        
        return Json(userList);
    }

    [HttpPost]
    public async Task Delete(long? id)
    {
        await mediator.Send(new DeleteUserRequest() { Id = id ?? 0 });
        ViewBag.Message = "Silme başarılı";
    }
}