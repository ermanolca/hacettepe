using System.Globalization;
using FluentValidation;
using FluentValidation.AspNetCore;
using FormHelper;
using Hacettepe.Application.Authentication;
using Hacettepe.Application.Database;
using Hacettepe.Web.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Hacettepe.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        
        builder.Services.AddDbContext<HacettepeDbContext>();
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        
        builder.Services.AddControllersWithViews().AddFormHelper(options => {
            options.CheckTheFormFieldsMessage = "Lütfen gerekli alanları doldurunuz";
            options.RedirectDelay = 6000;
            options.EmbeddedFiles = true;
            options.ToastrDefaultPosition = ToastrPosition.TopFullWidth;
        }).AddFluentValidation();

        builder.Services.AddRazorPages();
        
        builder.Services.AddValidatorsFromAssembly(typeof(LoginRequest).Assembly);
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(LoginRequest).Assembly);
            //cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();
        
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "hacettepehastanesi";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.SlidingExpiration = true;
                options.LoginPath = "/Admin/Login";
                options.AccessDeniedPath = "/Admin";
            });
        
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy =>
            {
                policy.RequireRole("Admin");
            });
        });

        var cultureInfo = new CultureInfo("tr-TR");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseFormHelper();
        
        app.MapControllerRoute(
            name: "areaRoute",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
        
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        
        app.MapControllerRoute(
            name: "routeViewPage",
            pattern: "{lang}/page/{slug}",
            defaults: new { controller = "ShowPage", action = "ShowPage" });
        
        app.UseCookiePolicy(new CookiePolicyOptions
        {
            MinimumSameSitePolicy = SameSiteMode.Strict,
        });
        
        app.MapRazorPages();
        app.UseExceptionHandler();
        
        app.Run();
    }
}