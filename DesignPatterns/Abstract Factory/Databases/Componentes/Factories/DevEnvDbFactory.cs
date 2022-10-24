using Databases.Base;
using Databases.Componentes.Environments.Develop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases.Componentes.Factories
{
    public class DevEnvDbFactory : DbFactory
    {
        public DBMongoContext CreateMongoContext() => new DevMongoContext();

        public DBRedisContext CreateRedisContext() => new DevRedisContext();

        public DBSQLContext CreateSQLContext() => new DevSQLContext();
    }
}
