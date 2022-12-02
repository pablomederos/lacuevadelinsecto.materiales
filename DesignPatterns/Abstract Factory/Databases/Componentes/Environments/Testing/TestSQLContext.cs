using LaCuevaDelInsecto.Databases.Base;

namespace LaCuevaDelInsecto.Databases.Componentes.Environments.Testing
{
    public class TestSQLContext: DBSQLContext
    {
        public override void CreateConnection()
        {
            //ConfigureDomain();

            ConfigureConnection("String de conexión de testing");

            Console.WriteLine($"Se creó conexión SQL  de testing: {IsConnected}");
        }

        //private void ConfigureDomain() { }
    }
}
