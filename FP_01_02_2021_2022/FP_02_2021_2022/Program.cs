using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EW_2021_PAP1_DB_alXXXXX>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EW_2021_PAP1_DB_alXXXXX") ?? throw new InvalidOperationException("Connection string 'EW_2021_PAP1_DB_alXXXXX' not found.")));

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
    pattern: "{controller=Livraria}/{action=Lista}/{id?}");

app.Run();
