using Databases.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases.Componentes.Environments.Develop
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
