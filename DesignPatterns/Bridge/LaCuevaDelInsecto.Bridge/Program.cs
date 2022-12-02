using LaCuevaDelInsecto.Bridge.Services.Bridge.Abstractions;
using LaCuevaDelInsecto.Bridge.Services.Bridge.Implementations;
using LaCuevaDelInsecto.Services.Bridge.Implementations;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();

// Inyección de dependencias
services.AddTransient<IPersonaService>( p => new PersonaService(
        new PostgresDBPersonaService() // Bridge
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
