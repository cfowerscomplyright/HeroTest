using HeroTest.Models;
using HeroTest.Services;
using HeroTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SampleContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("ObjectDB"));
  

}, ServiceLifetime.Transient);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
      options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddScoped<IHeroService, HeroService>();

var app = builder.Build();

app.UseCors(options =>
  options.WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "api default",
    pattern: "api/{controller}/{id}");

app.MapFallbackToFile("index.html"); ;

app.Run();
