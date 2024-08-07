using HGO.ASPNetCore.FileManager.CommandsProcessor;
using Microsoft.AspNetCore.Mvc;

namespace Hacettepe.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class FileManagerController(IFileManagerCommandsProcessor processor) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost, HttpGet]
    public async Task<IActionResult> Api(string id, string command, string parameters, IFormFile file)
    {
        return await processor.ProcessCommandAsync(id, command, parameters, file);
    }
}