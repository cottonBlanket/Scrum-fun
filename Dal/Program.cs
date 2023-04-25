using Dal;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();
    context.Response.Headers["ContentType"] = "aaplication/json";
});

app.Run();