using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TP_08.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TP_08Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TP_08Context") ?? throw new InvalidOperationException("Connection string 'TP_08Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Gera um cookie responsável por identificar a sessão.
// Este cookie, permite gerir na memória do servidor, um conjunto de dados que,
// pode ser utilizado entre pedidos.

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(10);
    option.Cookie.Name = ".AspNetCore.Session";
});

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(10);
    option.Cookie.Name = ".User.Session";
});

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

// Especifica que a aplica��o deve usar o cookie de sess�o.

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
