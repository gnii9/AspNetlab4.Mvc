using AspNetWeek2.Mvc.Data;
using AspNetWeek2.Mvc.Repositories;
using AspNetWeek2.Mvc.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>(); // ✅ THÊM DÒNG NÀY

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ISaleService, SaleService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();