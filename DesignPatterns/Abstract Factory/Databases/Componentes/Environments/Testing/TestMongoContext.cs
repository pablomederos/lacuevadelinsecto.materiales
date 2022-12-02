using LaCuevaDelInsecto.Databases.Base;

namespace LaCuevaDelInsecto.Databases.Componentes.Environments.Testing
{
    public class TestMongoContext : DBMongoContext
    {
        public override void CreateConnection()
        {
            //ConfigureDomain();

            ConfigureConnection("String de conexión de testing");

            Console.WriteLine($"Se creó conexión MongoDb de testing: {IsConnected}");
        }

        //private void ConfigureDomain() { }
    }
}
