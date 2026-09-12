using June2026.SignalRMvp.Hubs;

var builder = WebApplication.CreateBuilder(args);

// 1. Add MVC Controllers and SignalR Services to DI Container
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure HTTP Request Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 2. Map SignalR Hub Endpoint to "/mvpHub"
app.MapHub<MvpHub>("/mvpHub");

app.Run();
