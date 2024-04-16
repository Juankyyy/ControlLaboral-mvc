using ControlLaboral.Data;
using Microsoft.EntityFrameworkCore;
//Añadir los using de las carpetas providers y la carpetas helpers

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//Agregamos nuestro servicio de Mysql
builder.Services.AddDbContext<ControlLaboralContext>(options => options.UseMysql(
    builder.Configuration.GetConnectionString("MySQLConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
));
//Agregar el singleton de las carpetas Uploads Y providers

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
