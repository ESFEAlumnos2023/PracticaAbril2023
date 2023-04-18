using PracticaESFE.AppMVC.Models;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

const string strConnection = @"Data Source=.;Initial Catalog=OrdenesDB;Integrated Security=True;Trust Server Certificate=true";
builder.Services.AddDbContext<ESFEDB>(options =>
            options.UseSqlServer(strConnection));
builder.Services.AddScoped<UserEFDAL>();
builder.Services.AddScoped<CustomerEFDAL>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
