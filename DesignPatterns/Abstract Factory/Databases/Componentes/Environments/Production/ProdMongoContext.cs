using Databases.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases.Componentes.Environments.Production
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
