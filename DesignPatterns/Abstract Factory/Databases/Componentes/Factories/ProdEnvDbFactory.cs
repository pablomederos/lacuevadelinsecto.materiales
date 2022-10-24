using Databases.Base;
using Databases.Componentes.Environments.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases.Componentes.Factories
{
    public class ProdEnvDbFactory : DbFactory
    {
        public DBMongoContext CreateMongoContext() => new ProdMongoContext();

        public DBRedisContext CreateRedisContext() => new ProdRedisContext();

        public DBSQLContext CreateSQLContext() => new ProdSQLContext();
    }
}
