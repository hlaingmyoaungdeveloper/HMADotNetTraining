using Microsoft.AspNetCore.Mvc;

namespace June2026.MiddlewareWebApp.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(LoginRequestModel requestModel)
    {
        Response.Cookies.Append("Username", requestModel.Username);
        return Redirect("/home");
    }
}

public class LoginRequestModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}