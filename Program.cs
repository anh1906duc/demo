using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KT2.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<KT2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KT2Context") ?? throw new InvalidOperationException("Connection string 'KT2Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
