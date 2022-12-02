using LaCuevaDelInsecto.Databases.Base;

namespace LaCuevaDelInsecto.Databases.Componentes.Environments.Production
{
    public class ProdMongoContext : DBMongoContext
    {
        public override void CreateConnection()
        {
            //ConfigureDomain();

            ConfigureConnection("String de conexión de producción");

            Console.WriteLine($"Se creó conexión MongoDb de producción: {IsConnected}");
        }

        //private void ConfigureDomain() { }
    }
}
