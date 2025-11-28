using Microsoft.EntityFrameworkCore;
using FitnessApp.Data; // DbContext dosyasýný tanýmasý için

var builder = WebApplication.CreateBuilder(args);


// 1. Veritabaný Baðlantýsýný (Köprüyü) Ekliyoruz
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
// ---------------------------------------

// 2. MVC Sistemini Ekliyoruz
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3. Genel Ayarlar
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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