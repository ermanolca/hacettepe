using Hacettepe.Application.Pages;
using Hacettepe.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hacettepe.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class PagesController : Controller
{
    private IMediator _mediator;
    public PagesController(IMediator mediator)
    {
        _mediator = mediator;

    }
    
    [HttpGet]
    public ViewResult Create()
    {
        return View(new CreatePageRequest());
    }
    
    [HttpPost]
    public async Task<ViewResult> Create(CreatePageRequest createPageRequest)
    {
        var user = await _mediator.Send<Page?>(createPageRequest);
        if (user == null)
        {
            ModelState.AddModelError("", "Kaydetme başarısız");
            return View(createPageRequest);
        }
        
        return View(createPageRequest);
    }
    
}