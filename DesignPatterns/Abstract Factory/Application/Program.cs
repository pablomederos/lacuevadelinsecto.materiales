
using Application.App;
using Databases.Componentes.Factories;

// Configuración que puede venir de un archivo
Environment env = Environment.PRODUCTION;


// Ambientes en los que desplegamos nuestra app
_ = env switch
{
    Environment.DEVELOP => new ApplicationPrueba(
            new DevEnvDbFactory()
        ),
    Environment.TESTING => new ApplicationPrueba(
            new TestEnvDbFactory()
        ),
    Environment.PRODUCTION => new ApplicationPrueba(
            new ProdEnvDbFactory()
        ),
    _ => throw new NotImplementedException()
};



internal enum Environment
{
    DEVELOP,
    TESTING,
    PRODUCTION
}