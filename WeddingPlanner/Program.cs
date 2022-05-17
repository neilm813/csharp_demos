using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

var builder = WebApplication.CreateBuilder(args);

/******************************************************************************
Add Services to a dependency container so anything that depends on these
services can have them injected (passed in as an argument).

If you go to definition on the below Add methods, you will see the container is
a IServiceCollection and it's in the Microsoft.Extensions.DependencyInjection
namespace at the top.
******************************************************************************/

// Add a database connection.
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WeddingPlannerContext>(options =>
{
    options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString));
});

builder.Services.AddControllersWithViews();

/*
AddHttpContextAccessor gives our views direct access to session so that session
data doesn't need to be repeatedly passed into the ViewBag.

REQUIRES adding:
@using Microsoft.AspNetCore.Http into Views/_ViewImports.cshtml

Now in every view you can access session like this:
@Context.Session.GetString("KeyName")
*/
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();


var app = builder.Build();

/******************************************************************************
Enable middleware needed by our app. Middleware is used in the middle
of the HTTP request response cycle (after the request, before the response).

Some of these are available because they were added above as services.

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0

"Middleware is software that's assembled into an app pipeline to handle requests and
responses.

Each component:
    - Chooses whether to pass the request to the next component in the pipeline.
    - Can perform work before and after the next component in the pipeline."
******************************************************************************/

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();