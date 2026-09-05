using DependencyInjectionDemo.Interfaces;
using DependencyInjectionDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register the DI lifetimes
builder.Services.AddTransient<ITransientOperation, DefaultOperation>();
builder.Services.AddScoped<IScopedOperation, DefaultOperation>();
builder.Services.AddSingleton<ISingletonOperation, DefaultOperation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
