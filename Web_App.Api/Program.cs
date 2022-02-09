using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Business;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.EF;
using RepositoryPatternWithUOW.EF.Repositores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Configuration.AddJsonFile("appsettings.json", false, true);

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<> ));
builder.Services.AddTransient<IDrinksService,DrinksService>();
builder.Services.AddTransient<ICoinsService, CoinsService>();
builder.Services.AddTransient<ICoinsRepository, CoinsRepository>();
builder.Services.AddTransient<IDrinkRepository, DrinkRepository>();
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
    pattern: "{controller=Client}/{action=Index}/{id?}");

app.Run();
