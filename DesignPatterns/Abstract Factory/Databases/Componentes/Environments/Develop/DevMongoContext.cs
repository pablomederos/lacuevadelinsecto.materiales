using LaCuevaDelInsecto.Databases.Base;

namespace LaCuevaDelInsecto.Databases.Componentes.Environments.Develop
{
    public class DevMongoContext : DBMongoContext
    {
        public override void CreateConnection()
        {
            //ConfigureDomain();

            ConfigureConnection("String de conexión de desarrollo");

            Console.WriteLine($"Se creó conexión MongoDb de desarrollo: {IsConnected}");
        }

        //private void ConfigureDomain() { }
    }
}
