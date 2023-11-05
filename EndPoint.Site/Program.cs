using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Shop_Mobile.Application.Interfaces.Contexts;
using Shop_Mobile.Application.Interfaces.FacadPatterns;
using Shop_Mobile.Application.Services.Products.FacadPattern;
using Shop_Mobile.Application.Services.Users.Commands.EditUser;
using Shop_Mobile.Application.Services.Users.Commands.LoginUser;
using Shop_Mobile.Application.Services.Users.Commands.RegisterUser;
using Shop_Mobile.Application.Services.Users.Commands.RemoveUser;
using Shop_Mobile.Application.Services.Users.Commands.UserSatusChange;
using Shop_Mobile.Application.Services.Users.Queries.GetRoles;
using Shop_Mobile.Application.Services.Users.Queries.GetUsers;
using Shop_Mobile.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();

//Facad Inject
builder.Services.AddScoped<IProductFacad, ProductFacad>();

builder.Services.AddDbContext<DataBaseContext>(x => 
x.UseSqlServer(builder.Configuration.GetConnectionString("Shop_Mobile")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
   name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
