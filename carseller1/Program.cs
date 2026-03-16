using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using carseller1.Data;
using carseller1.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("carseller1Context")
    ?? throw new InvalidOperationException("Connection string 'carseller1Context' not found.");

builder.Services.AddDbContext<carseller1Context>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<VehicleService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<UserService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var enUs = new CultureInfo("en-US");
var localizationOption = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUs),
    SupportedCultures = new List<CultureInfo> { enUs },
    SupportedUICultures = new List<CultureInfo> { enUs }
};
app.UseRequestLocalization(localizationOption);


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
