using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hacettepe.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class HomeController: Controller
{
    private readonly ILogger<HomeController> _logger;
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public LocalRedirectResult Index()
    {
        return LocalRedirect("/admin/pages/Create/");
    }
}