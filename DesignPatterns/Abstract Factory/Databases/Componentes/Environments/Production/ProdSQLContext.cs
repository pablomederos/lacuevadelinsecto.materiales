using LaCuevaDelInsecto.Databases.Base;

namespace LaCuevaDelInsecto.Databases.Componentes.Environments.Production
{
    public class ProdSQLContext: DBSQLContext
    {
        public override void CreateConnection()
        {
            //ConfigureDomain();

            ConfigureConnection("String de conexión de producción");

            Console.WriteLine($"Se creó conexión SQL  de producción: {IsConnected}");
        }

        //private void ConfigureDomain() { }
    }
}
