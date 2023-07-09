using kudvenkitPractice.DAL;
using kudvenkitPractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using kudvenkitPractice.Repositories;

var builder = WebApplication.CreateBuilder(args);
var _config = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContextPool<appDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDbConnectionString")));

builder.Services.AddRazorPages();
builder.Services.AddMvcCore() ;

builder.Services.AddScoped< IEmployeeRepository, SQLEmployeeRepository >();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();}

app.UseStaticFiles();
//app.UseMvcWithDefaultRoute();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller = Home]}/{action = Index]}/{id?}");
app.Run();

    //app.Run(async(context) =>
    //{
    //    await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
  
    //});
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello World");
//});
