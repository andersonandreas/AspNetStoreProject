using AspNetStoreProject.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

var connectionsString = builder.Configuration.GetConnectionString("AspNetStoreDb");

builder.Services.AddDbContext<StoreDbContext>(options =>
{
	options.UseSqlServer(connectionsString);
});


builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

SeedData.MakeSureDbIsPopulated(app);

app.UseAuthorization();

app.MapControllers();

app.Run();
