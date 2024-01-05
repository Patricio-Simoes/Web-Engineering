using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FP_01_2021_2022.Data;
using NuGet.ContentModel;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FP_01_2021_2022Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FP_01_2021_2022Context") ?? throw new InvalidOperationException("Connection string 'FP_01_2021_2022Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Contactos}/{action=Lista}/{id?}");

app.MapControllerRoute(
    name: "FiltroAmigos1",
    pattern: "/Amigos",
    defaults: new {Controller = "Contactos", Action = "Lista", flag = true});

app.MapControllerRoute(
    name: "FiltroAmigos2",
    pattern: "/Contactos/Lista/Amigos",
    defaults: new { Controller = "Contactos", Action = "Lista", flag = true });


app.Run();
