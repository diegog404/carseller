using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using carseller.Data;
using carseller.Services;
var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("carsellerContext")
    ?? throw new InvalidOperationException("Connection string 'carsellerContext' not found.");

builder.Services.AddDbContext<carsellerContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<CompanyService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
