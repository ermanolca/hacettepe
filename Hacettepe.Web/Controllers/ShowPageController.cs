using Hacettepe.Application.Pages;
using Hacettepe.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hacettepe.Web.Controllers;

public class ShowPageController(IMediator mediator) : Controller
{
    public async Task<ViewResult> ShowPage([FromRoute]string slug)
    {
        var page = await mediator.Send<Page?>(new ViewPageRequest(){Slug = slug});
        return View(page ?? new Page());
    }   
}