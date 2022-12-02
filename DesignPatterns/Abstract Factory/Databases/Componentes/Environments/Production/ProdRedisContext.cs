using LaCuevaDelInsecto.Databases.Base;

namespace LaCuevaDelInsecto.Databases.Componentes.Environments.Production
{
    public class ProdRedisContext: DBRedisContext
    {
        public override void CreateConnection()
        {
            //ConfigureDomain();

            ConfigureConnection("String de conexión de producción");

            Console.WriteLine($"Se creó conexión Redis de producción: {IsConnected}");
        }

        //private void ConfigureDomain() { }
    }
}
