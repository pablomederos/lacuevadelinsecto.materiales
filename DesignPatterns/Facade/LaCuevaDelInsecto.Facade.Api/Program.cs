using LaCuevaDelInsecto.StarWarsApiConsumer;

namespace LaCuevaDelInsecto.Facade.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        IServiceCollection services = builder.Services;

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // Servicio Provisorio para el controlador WithoutFacede
        services.AddSingleton<SwapiClient>();

        // Servicio Provisorio para el controlador WithFacade
        services.AddSingleton<SwapiFacade>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

