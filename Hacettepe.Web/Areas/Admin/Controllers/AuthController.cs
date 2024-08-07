using System.Security.Claims;
using Hacettepe.Application.Common;
using Hacettepe.Application.Users.Password;
using Hacettepe.Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = Hacettepe.Application.Authentication.LoginRequest;

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
            new(ClaimTypes.Email, loginRequest.Email),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Role, user.Role.ToString()),
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
    
    [Route("/admin/forgotpassword")]
    [HttpGet]
    public ViewResult ForgotPassword()
    {
        return View(new ForgotPasswordRequest());
    }
    
    [Route("/admin/forgotpassword")]
    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest)
    {
        await _mediator.Send(forgotPasswordRequest);
        ViewBag.Message = "Şifre yenileme isteğiniz kayıtlı eposta adresinize gönderilmiştir";
        return View(new ForgotPasswordRequest());
    }
    
    [Route("/admin/renewpassword/{token}")]
    [HttpGet]
    public ViewResult RenewPassword(string token)
    {
        return View(new RenewPasswordRequest() { Token = token});
    }
    
    [Route("/admin/renewpassword")]
    [HttpPost]
    public async Task<IActionResult> RenewPassword(RenewPasswordRequest renewPasswordRequest)
    {
        var result = await _mediator.Send<HandlerResult>(renewPasswordRequest);
        ViewBag.Message = result.Message;
        if (result.IsSuccess)
        {
            return RedirectToAction("LogIn", "Auth", new { area = "Admin" });
        }
        
        return View(renewPasswordRequest);
    }
    
    [HttpGet]
    [Authorize]
    [Route("/admin/logout")]
    public async Task<IActionResult> Signout(string returnUrl = null)
    {
        // Clear the existing external cookie
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return LocalRedirect("/admin/login");
    }
}