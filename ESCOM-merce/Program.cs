using ESCOM_merce.Models;
using ESCOM_merce.Services;
using Microsoft.AspNetCore.Authentication.Cookies; ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.Configure<BaseSettings>(
    builder.Configuration.GetSection("BaseSettings"));
builder.Services.Configure<ProductosSettings>(
    builder.Configuration.GetSection("ProductosSettings"));
builder.Services.AddSingleton<UsuariosApi>();
builder.Services.AddSingleton<ProductosApi>();
builder.Services.AddSingleton<VentasApi>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/VUsuario/Login";
    option.ExpireTimeSpan=TimeSpan.FromMinutes(30);
    option.AccessDeniedPath = "/Home/Privacy";
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "UsuariosApi");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
