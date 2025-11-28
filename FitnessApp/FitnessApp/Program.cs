var builder = WebApplication.CreateBuilder(args);

// --- BURASI EKSİKTİ, ŞİMDİ EKLİYORUZ ---
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