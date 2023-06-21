using Application.IService;
using Application.Service;
using DataAccess;
using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ClubConquistadoresAguilasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

//Inyeccion de dependencias
//User
builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
//Person
builder.Services.AddScoped<IGenericRepository<Person>, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
//Activity

//Club


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Home/Error");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();*/

app.MapControllerRoute(
    "default",
    "{controller=Login}/{action=Login}/{id?}");

app.Run();