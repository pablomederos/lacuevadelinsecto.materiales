using LaCuevaDelInsecto.Databases.Base;

namespace LaCuevaDelInsecto.Databases.Componentes.Environments.Develop
{
    public class DevSQLContext: DBSQLContext
    {
        public override void CreateConnection()
        {
            //ConfigureDomain();

            ConfigureConnection("String de conexión de desarrollo");

            Console.WriteLine($"Se creó conexión SQL  de desarrollo: {IsConnected}");
        }

        //private void ConfigureDomain() { }
    }
}
