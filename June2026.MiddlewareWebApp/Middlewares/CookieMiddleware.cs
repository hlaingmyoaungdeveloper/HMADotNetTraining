namespace June2026.MiddlewareWebApp.Middlewares;

public class CookieMiddleware
{
    public readonly RequestDelegate _next;

    public CookieMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.ToString().ToLower() != "/login" &&
           context.Request.Path.ToString().ToLower() != "/login/Index")
        {
            if (!context.Request.Cookies.Any(x => x.Key == "Username"))
            {
                context.Response.Redirect("/login");
            }
        }
        await _next(context);

    }
}

public static class CookieMiddlewareExtension
{
    public static void UseCookieMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<CookieMiddleware>();
    }
}
