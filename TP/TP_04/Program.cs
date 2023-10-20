using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TP_04.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TP_04Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TP_04Context") ?? throw new InvalidOperationException("Connection string 'TP_04Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<DbInitializer>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var initializer = services.GetRequiredService<DbInitializer>();

initializer.Run();

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
