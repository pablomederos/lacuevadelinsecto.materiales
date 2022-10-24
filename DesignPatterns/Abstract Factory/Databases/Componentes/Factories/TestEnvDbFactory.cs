using Databases.Base;
using Databases.Componentes.Environments.Develop;
using Databases.Componentes.Environments.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases.Componentes.Factories
{
    public class TestEnvDbFactory : DbFactory
    {
        public DBMongoContext CreateMongoContext() => new TestMongoContext();

        public DBRedisContext CreateRedisContext() => new TestRedisContext();

        public DBSQLContext CreateSQLContext() => new TestSQLContext();
    }
}
