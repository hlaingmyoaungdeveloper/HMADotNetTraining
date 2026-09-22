using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace June2026.MiddlewareWebApp.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> IndexAsync(LoginRequestModel requestModel)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, requestModel.Username),
                new Claim(ClaimTypes.Role, requestModel.Username),
                new Claim("LastLogin", DateTime.UtcNow.ToString())
            };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = requestModel.RememberMe, // "Remember me" option
            ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
        return Redirect("/home");
    }
}

public class LoginRequestModel
{
    public string Username { get; set; }
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}