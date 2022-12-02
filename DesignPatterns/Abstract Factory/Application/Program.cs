
using LaCuevaDelInsecto.Application.App;
using LaCuevaDelInsecto.Databases.Componentes.Factories;

// Configuración que puede venir de un archivo
Environment env = Environment.PRODUCTION;


// Ambientes en los que desplegamos nuestra app
// Esto no es parte del patrón, lo añadí para 
// que la ejecución sea más visualmente clara.
_ = env switch
{
    Environment.DEVELOP => new ApplicationTest(
            new DevEnvDbFactory()
        ),
    Environment.TESTING => new ApplicationTest(
            new TestEnvDbFactory()
        ),
    Environment.PRODUCTION => new ApplicationTest(
            new ProdEnvDbFactory()
        ),
    _ => throw new NotImplementedException()
};

Console.Read();




internal enum Environment
{
    DEVELOP,
    TESTING,
    PRODUCTION
}