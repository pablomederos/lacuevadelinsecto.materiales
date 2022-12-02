using LaCuevaDelInsecto.Databases.Base;

namespace LaCuevaDelInsecto.Databases.Componentes.Environments.Develop
{
    public class DevRedisContext: DBRedisContext
    {
        public override void CreateConnection()
        {
            //ConfigureDomain();

            ConfigureConnection("String de conexión de desarrollo");

            Console.WriteLine($"Se creó conexión Redis de desarrollo: {IsConnected}");
        }

        //private void ConfigureDomain() { }
    }
}
