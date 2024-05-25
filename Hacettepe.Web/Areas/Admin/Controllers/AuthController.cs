using System.Security.Claims;
using Hacettepe.Application.Authentication;
using Hacettepe.Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Hacettepe.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class AuthController: Controller
{
    private IMediator _mediator;
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;

    }
    [Route("/admin/login")]
    [HttpGet]
    public ViewResult Login()
    {
        return View(new LoginRequest());
    }

    [HttpPost]
    [Route("/admin/login")]
    [FormValidator(UseAjax = false)]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var user = await _mediator.Send<User?>(loginRequest);
        if (user == null)
        {
            ModelState.AddModelError("", "Kullanıcı bulunamadı");
            return View(loginRequest);
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, loginRequest.Email)
        };
        
        var claimsIdentity=new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            new AuthenticationProperties
            {
                IsPersistent = loginRequest.RememberMe
            });

        return LocalRedirect("/admin/Pages/Create/");
    }
    
    [HttpGet]
    [Route("/admin/logout")]
    public async Task<IActionResult> Signout(string returnUrl = null)
    {
        // Clear the existing external cookie
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return LocalRedirect("/admin/login");
    }
}