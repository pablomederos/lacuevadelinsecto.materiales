using LaCuevaDelInsecto.Databases.Base;

namespace LaCuevaDelInsecto.Databases.Componentes.Environments.Testing
{
    public class TestRedisContext: DBRedisContext
    {
        public override void CreateConnection()
        {
            //ConfigureDomain();

            ConfigureConnection("String de conexión de testing");

            Console.WriteLine($"Se creó conexión Redis de testing: {IsConnected}");
        }

        //private void ConfigureDomain() { }
    }
}
