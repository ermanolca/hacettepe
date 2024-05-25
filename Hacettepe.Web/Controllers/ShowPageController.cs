using Hacettepe.Application.Pages;
using Hacettepe.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hacettepe.Web.Controllers;

public class ShowPageController : Controller
{
    private IMediator _mediator;
    public ShowPageController(IMediator mediator)
    {
        _mediator = mediator;

    }
    
    public async Task<ViewResult> ShowPage([FromRoute]string lang, [FromRoute]string slug)
    {
        var page = await _mediator.Send<Page?>(new ViewPageRequest(){Slug = slug});
        return View(page ?? new Page());
    }   
}